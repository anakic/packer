//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.9.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from c:\Projects\Packer\Packer2.Library\MinifiedQueryParser\pbiqParser.g4 by ANTLR 4.9.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace Packer2 {
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="pbiqParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.9.2")]
[System.CLSCompliant(false)]
public interface IpbiqParserVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.query"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitQuery([NotNull] pbiqParser.QueryContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.from"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFrom([NotNull] pbiqParser.FromContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.fromElement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFromElement([NotNull] pbiqParser.FromElementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.where"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWhere([NotNull] pbiqParser.WhereContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.queryFilter"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitQueryFilter([NotNull] pbiqParser.QueryFilterContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.alias"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAlias([NotNull] pbiqParser.AliasContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.entity"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEntity([NotNull] pbiqParser.EntityContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.entity_name"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEntity_name([NotNull] pbiqParser.Entity_nameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.schema"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSchema([NotNull] pbiqParser.SchemaContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.expressionContainer"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpressionContainer([NotNull] pbiqParser.ExpressionContainerContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.orderby"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOrderby([NotNull] pbiqParser.OrderbyContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.groupby"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitGroupby([NotNull] pbiqParser.GroupbyContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.skip"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSkip([NotNull] pbiqParser.SkipContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.top"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTop([NotNull] pbiqParser.TopContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.orderbySection"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOrderbySection([NotNull] pbiqParser.OrderbySectionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.direction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDirection([NotNull] pbiqParser.DirectionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.algorithm"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAlgorithm([NotNull] pbiqParser.AlgorithmContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.select"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSelect([NotNull] pbiqParser.SelectContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpression([NotNull] pbiqParser.ExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.nonPropertyExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNonPropertyExpression([NotNull] pbiqParser.NonPropertyExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.nonFilterExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNonFilterExpression([NotNull] pbiqParser.NonFilterExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.filterExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFilterExpression([NotNull] pbiqParser.FilterExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.sourceRefExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSourceRefExpr([NotNull] pbiqParser.SourceRefExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.aggregationExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAggregationExpr([NotNull] pbiqParser.AggregationExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.anyValueExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAnyValueExpr([NotNull] pbiqParser.AnyValueExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.andExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAndExpr([NotNull] pbiqParser.AndExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.betweenExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBetweenExpr([NotNull] pbiqParser.BetweenExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.nullEpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNullEpr([NotNull] pbiqParser.NullEprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.intExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIntExpr([NotNull] pbiqParser.IntExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.decimalExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDecimalExpr([NotNull] pbiqParser.DecimalExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.datetimeExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDatetimeExpr([NotNull] pbiqParser.DatetimeExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.dateExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDateExpr([NotNull] pbiqParser.DateExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.datetimeSecExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDatetimeSecExpr([NotNull] pbiqParser.DatetimeSecExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.containsExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitContainsExpr([NotNull] pbiqParser.ContainsExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.stringExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStringExpr([NotNull] pbiqParser.StringExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.boolExp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBoolExp([NotNull] pbiqParser.BoolExpContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.orExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOrExpr([NotNull] pbiqParser.OrExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.comparisonExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitComparisonExpr([NotNull] pbiqParser.ComparisonExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.propertyExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPropertyExpression([NotNull] pbiqParser.PropertyExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.notExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNotExpr([NotNull] pbiqParser.NotExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.literalExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLiteralExpr([NotNull] pbiqParser.LiteralExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.inExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInExpr([NotNull] pbiqParser.InExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.inExprValues"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInExprValues([NotNull] pbiqParser.InExprValuesContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.expressionOrExpressionList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpressionOrExpressionList([NotNull] pbiqParser.ExpressionOrExpressionListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.arithmenticExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArithmenticExpr([NotNull] pbiqParser.ArithmenticExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.orderByClause"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOrderByClause([NotNull] pbiqParser.OrderByClauseContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.tableName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTableName([NotNull] pbiqParser.TableNameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.equalityKind"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEqualityKind([NotNull] pbiqParser.EqualityKindContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.left"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLeft([NotNull] pbiqParser.LeftContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.right"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRight([NotNull] pbiqParser.RightContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.ubound"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUbound([NotNull] pbiqParser.UboundContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.lbound"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLbound([NotNull] pbiqParser.LboundContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="pbiqParser.operator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOperator([NotNull] pbiqParser.OperatorContext context);
}
} // namespace Packer2
