﻿using Microsoft.AnalysisServices.Tabular;
using Microsoft.Extensions.Logging;
using Packer2.Library.Tools;
using System.Text.RegularExpressions;

namespace Packer2.Library.DataModel.Transofrmations
{
    public class PasswordResolveTransform : IDataModelTransform
    {
        private readonly ILogger<PasswordResolveTransform> logger;

        public PasswordResolveTransform(ILogger<PasswordResolveTransform> logger = null)
        {
            this.logger = logger ?? new DummyLogger<PasswordResolveTransform>();
        }

        public Database Transform(Database database)
        {
            foreach (var ds in database.Model.DataSources.OfType<StructuredDataSource>())
            {
                var pwd = ds.Credential.Password;
                var m = Regex.Match(pwd, @"{(?'name'[^}]+)}");
                if (m.Success)
                {
                    var value = Environment.GetEnvironmentVariable(m.Groups["name"].Value);
                    if (value != null)
                    {
                        logger.LogInformation("Filling password placeholder '{passwordPlaceholder}' in data source '{dataSource}'", value, ds.Name);
                        ds.Credential.Password = value;
                    }
                    else
                    {
                        logger.LogInformation("Found password placeholder '{passwordPlaceholder}' in data source '{dataSource}' but a matching environment variable has not been found.", value, ds.Name);
                        // todo: prompt user for password?
                    }
                }
            }
            return database;
        }
    }
}
