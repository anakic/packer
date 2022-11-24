﻿using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Microsoft.InfoNav.Data.Contracts.Internal;
using Packer2.Library.MinifiedQueryParser.QueryTransforms;
using System.Runtime.CompilerServices;

namespace Packer2.Library.Report.QueryTransforms.Antlr
{
    public partial class QueryParser
    {
        class QueryExpressionVisitor : pbiqParserBaseVisitor<QueryExpression>
        {
            private readonly Dictionary<string, string> sourceNames;
            private readonly HashSet<string> transformTableNames;
            private readonly ColumnsAndMeasuresGlossary glossary;
            private ParserResultValidator validator;
            private readonly bool standalone;

            public QueryExpression VisitValidated(IParseTree tree)
            {
                var res = Visit(tree);
                if (res == null)
                    throw new Exception("Failed to resolve query");

                validator.ValidateExpression(res, standalone);

                return res;
            }

            public QueryExpressionVisitor(ColumnsAndMeasuresGlossary glossary, ParserResultValidator validator, bool standalone, Dictionary<string, string> sourceNames, HashSet<string> transformTableNames)
            {
                this.glossary = glossary;
                this.validator = validator;
                this.standalone = standalone;
                this.sourceNames = sourceNames;
                this.transformTableNames = transformTableNames;
            }

            public override QueryExpression VisitRoleRefExpression([NotNull] pbiqParser.RoleRefExpressionContext context)
            {
                return new QueryRoleRefExpression() { Role = context.QUOTED_IDENTIFIER().GetText().TrimStart('[').TrimEnd(']') };
            }

            public override QueryExpression VisitArithmenticExpr([NotNull] pbiqParser.ArithmenticExprContext context)
            {
                var left = context.left();
                var right = context.right();
                var opeartor = ParseOperator(context.binary_arithmetic_operator().GetText());
                return new QueryArithmeticExpression()
                {
                    Left = VisitValidated(left),
                    Right = VisitValidated(right),
                    Operator = opeartor
                };
            }

            private QueryArithmeticOperatorKind ParseOperator(string v)
            {
                switch (v)
                {
                    case "-":
                        return QueryArithmeticOperatorKind.Subtract;
                    case "+":
                        return QueryArithmeticOperatorKind.Add;
                    case "*":
                        return QueryArithmeticOperatorKind.Multiply;
                    case "/":
                        return QueryArithmeticOperatorKind.Divide;
                    default:
                        throw new ArgumentException("Invalid operator");
                }
            }

            public override QueryExpression VisitScopedEvalExpr([NotNull] pbiqParser.ScopedEvalExprContext context)
            {
                var expression = VisitValidated(context.expression()[0]);
                var scopes = context.expression().Skip(1).Select(ctx => (QueryExpressionContainer)VisitValidated(ctx)).ToList();
                return new QueryScopedEvalExpression()
                {
                    Expression = expression,
                    Scope = scopes
                };
            }

            public override QueryExpression VisitVariationExpr([NotNull] pbiqParser.VariationExprContext context)
            {
                var expression = VisitValidated(context.sourceRefExpr());
                if (context.identifier().Count() != 2)
                    throw new FormatException("Variation syntax is: expr.variation(property, name). Expecting two identifiers (property and name)!");
                var property = UnescapeIdentifier(context.identifier().ElementAt(0).GetText());
                var name = UnescapeIdentifier(context.identifier().ElementAt(1).GetText());

                return new QueryPropertyVariationSourceExpression()
                {
                    Expression = expression,
                    Property = property,
                    Name = name
                };
            }

            public override QueryExpression VisitHierarchyExpr([NotNull] pbiqParser.HierarchyExprContext context)
            {
                var hierarchy = UnescapeIdentifier(context.identifier().GetText());
                var expression = VisitValidated(context.hierarchySource());

                return new QueryHierarchyExpression()
                {
                    Hierarchy = hierarchy,
                    Expression = expression
                };
            }

            public override QueryExpression VisitAggregationExpr([NotNull] pbiqParser.AggregationExprContext context)
            {
                var expression = VisitValidated(context.expression());
                var function = ParseFunction(context.identifier().GetText());
                return new QueryAggregationExpression()
                {
                    Expression = expression,
                    Function = function
                };
            }

            private string ReadStringLiteral(ITerminalNode node)
            {
                var text = node.GetText();
                return text.Substring(1, text.Length - 2);
            }

            public override QueryExpression VisitTransformOutputRoleRefExpr([NotNull] pbiqParser.TransformOutputRoleRefExprContext context)
            {
                return new QueryTransformOutputRoleRefExpression() { Role = ReadStringLiteral(context.STRING_LITERAL()) };
            }

            private QueryAggregateFunction ParseFunction(string v)
            {
                return (QueryAggregateFunction)Enum.Parse(typeof(QueryAggregateFunction), v, true);
            }

            public override QueryExpression VisitSubQueryExpr([NotNull] pbiqParser.SubQueryExprContext context)
            {
                var queryDefVisitor = new QueryConstructorVisitor(glossary, validator);
                var query = queryDefVisitor.Visit(context.query());

                return new QuerySubqueryExpression() { Query = query };
            }

            public override QueryExpression VisitHierarchyLevelExpr([NotNull] pbiqParser.HierarchyLevelExprContext context)
            {
                var expression = VisitValidated(context.hierarchyExpr());
                var level = UnescapeIdentifier(context.identifier().GetText());
                return new QueryHierarchyLevelExpression()
                {
                    Expression = expression,
                    Level = level
                };
            }

            public override QueryExpression VisitInExpr([NotNull] pbiqParser.InExprContext context)
            {
                var expression = new QueryInExpression();
                if (context.sourceRefExpr() != null)
                    expression.Table = new QueryExpressionContainer(VisitValidated(context.sourceRefExpr()));
                else
                {
                    if (context.inExprValues().inExprEqualityKind() != null)
                        expression.EqualityKind = context.inExprValues().inExprEqualityKind().identifier().GetText().ToLower() == "identity" ? QueryEqualitySemanticsKind.Identity : QueryEqualitySemanticsKind.Equality;

                    expression.Values = context.inExprValues()
                        .expressionOrExpressionList()
                        .Select(el => el.expression().Select(exp => new QueryExpressionContainer(VisitValidated(exp))).ToList()).ToList();
                }

                if (context.primary_expression() != null)
                    expression.Expressions = new List<QueryExpressionContainer>() { VisitValidated(context.primary_expression()) };
                else
                    expression.Expressions = context.expression().Select(exp => new QueryExpressionContainer(VisitValidated(exp))).ToList();
                return expression;
            }

            public override QueryExpression VisitSourceRefExpr([NotNull] pbiqParser.SourceRefExprContext context)
            {
                var name = UnescapeIdentifier(context.identifier().GetText());

                if (transformTableNames.Contains(name))
                {
                    return new QueryTransformTableRefExpression() { Source = name };
                }
                else
                {
                    // todo: what is the schema? the schema is not saved to the minified query.
                    var expression = new QuerySourceRefExpression();
                    if (sourceNames.ContainsKey(name))
                        expression.Source = name;
                    else
                    {
                        // todo: if we do add a reference to the model (to distinguish between column and measure properties), we should check that the entity exists
                        expression.Entity = name;
                    }
                    return expression;
                }
            }

            public override QueryExpression VisitIntExpr([NotNull] pbiqParser.IntExprContext context)
            {
                var text = context.INTEGER().GetText();
                if (text.Last() != 'L')
                    throw new FormatException("Invalid input");

                return new QueryIntegerConstantExpression() { Value = long.Parse(text.Substring(0, text.Length - 1)) };
            }

            public override QueryExpression VisitPropertyExpression([NotNull] pbiqParser.PropertyExpressionContext context)
            {
                var expressionContainer = (QueryExpressionContainer)VisitValidated((ParserRuleContext)context.sourceRefExpr() ?? context.subQueryExpr());
                var property = UnescapeIdentifier(context.identifier().GetText());

                if (expressionContainer.TransformTableRef != null)
                {
                    if (!transformTableNames.Contains(expressionContainer.TransformTableRef.Source))
                        throw new Exception("Invalid output transform name");
                    return new QueryColumnExpression()
                    {
                        Expression = expressionContainer,
                        Property = property
                    };
                }

                string entity = null;
                if (expressionContainer.SourceRef != null)
                    entity = expressionContainer.SourceRef.Entity ?? sourceNames[expressionContainer.SourceRef.Source];

                if (entity != null && glossary.IsMeasure(entity, property))
                {
                    return new QueryMeasureExpression()
                    {
                        Expression = expressionContainer,
                        Property = property
                    };
                }
                else if (entity != null && glossary.IsColumn(entity, property))
                {
                    return new QueryColumnExpression()
                    {
                        Expression = expressionContainer,
                        Property = property
                    };
                }
                else
                {
                    if (expressionContainer.Expression is QuerySubqueryExpression se)
                    {
                        var selectExpr = se.Query.Select.Select(x => (QueryPropertyExpression)x.Expression).SingleOrDefault(ec =>
                        {
                            var sourceNames = se.Query.From.ToDictionary(f => f.Name, f => f.Entity) ?? new Dictionary<string, string>();
                            if (se.Query.Transform != null)
                            {
                                se.Query.Transform.Select(t => t.Input?.Table.Name).Where(x => x != null).ToList().ForEach(t => sourceNames.Add(t, t));
                                se.Query.Transform.Select(t => t.Output?.Table.Name).Where(x => x != null).ToList().ForEach(t => sourceNames.Add(t, t));
                            }

                            if (ec.Expression.SourceRef != null)
                            {
                                var sourceRef = ec.Expression.SourceRef;
                                var entityName = sourceRef.Entity ?? sourceNames[sourceRef.Source];
                                return $"{entityName}.{ec.Property}" == property;
                            }
                            else if (ec.Expression.TransformTableRef != null)
                            {
                                return ec.Property == property;
                            }
                            else
                                throw new NotImplementedException("Unexpected element in subquery's select list");
                        });

                        if (selectExpr is QueryColumnExpression)
                        {
                            return new QueryColumnExpression()
                            {
                                Expression = expressionContainer,
                                Property = property
                            };
                        }
                        else if (selectExpr is QueryMeasureExpression)
                        {
                            return new QueryMeasureExpression()
                            {
                                Expression = expressionContainer,
                                Property = property
                            };
                        }
                    }

                    return new QueryPropertyExpression()
                    {
                        Expression = expressionContainer,
                        Property = property
                    };
                }
            }


            public override QueryExpression VisitEncodedLiteralExpr([NotNull] pbiqParser.EncodedLiteralExprContext context)
            {
                return new QueryLiteralExpression() { Value = context.GetText() };
            }

            public override QueryExpression VisitNotExpr([NotNull] pbiqParser.NotExprContext context)
            {
                return new QueryNotExpression() { Expression = VisitValidated(context.expression()) };
            }

            public override QueryExpression VisitBetweenExpr([NotNull] pbiqParser.BetweenExprContext context)
            {
                return new QueryBetweenExpression()
                {
                    Expression = VisitValidated(context.primary_expression()),
                    LowerBound = VisitValidated(context.left()),
                    UpperBound = VisitValidated(context.right())
                };
            }

            public override QueryExpression VisitDateSpanExpr([NotNull] pbiqParser.DateSpanExprContext context)
            {
                return new QueryDateSpanExpression()
                {
                    TimeUnit = ParseTimeUnit(context.timeUnit().GetText()),
                    Expression = VisitValidated(context.expression())
                };
            }

            private TimeUnit ParseTimeUnit(string v)
            {
                return (TimeUnit)Enum.Parse(typeof(TimeUnit), v, true);
            }

            public override QueryExpression VisitCompareExpr([NotNull] pbiqParser.CompareExprContext context)
            {
                var left = VisitValidated(context.primary_expression());
                var right = VisitValidated(context.right());

                return new QueryComparisonExpression()
                {
                    ComparisonKind = GetComparisonKind(context.comparisonOperator()),
                    Left = left,
                    Right = right,
                };
            }

            private QueryComparisonKind GetComparisonKind(pbiqParser.ComparisonOperatorContext operatorContext)
            {
                if (operatorContext.GT() != null)
                    return QueryComparisonKind.GreaterThan;
                else if (operatorContext.GTE() != null)
                    return QueryComparisonKind.GreaterThanOrEqual;
                if (operatorContext.LT() != null)
                    return QueryComparisonKind.LessThan;
                else if (operatorContext.LTE() != null)
                    return QueryComparisonKind.LessThanOrEqual;
                else
                    return QueryComparisonKind.Equal;
            }

            public override QueryExpression VisitContainsExpr([NotNull] pbiqParser.ContainsExprContext context)
            {
                return new QueryContainsExpression()
                {
                    Left = VisitValidated(context.primary_expression()),
                    Right = VisitValidated(context.right())
                };
            }

            protected override QueryExpression AggregateResult(QueryExpression aggregate, QueryExpression nextResult)
            {
                return nextResult ?? aggregate;
            }

            public override QueryExpression VisitLogicalExpr([NotNull] pbiqParser.LogicalExprContext context)
            {
                var left = VisitValidated(context.left());
                var right = VisitValidated(context.right());

                if (context.binary_logic_operator().GetText().ToLower() == "and")
                    return new QueryAndExpression() { Left = left, Right = right };
                else if (context.binary_logic_operator().GetText().ToLower() == "or")
                    return new QueryOrExpression() { Left = left, Right = right };
                else
                    throw new FormatException("Invalid logical operator");
            }

            //public override QueryExpression VisitBoolExp([NotNull] pbiqParser.BoolExpContext context)
            //{
            //    return new QueryBooleanConstantExpression()
            //    {
            //        Value = context.TRUE() != null
            //    };
            //}

            //public override QueryExpression VisitNullEpr([NotNull] pbiqParser.NullEprContext context)
            //{
            //    return new QueryNullConstantExpression();
            //}
        }
    }
}
