﻿using Microsoft.AnalysisServices.Tabular;

namespace DataModelLoader
{
    public class SSASDataModelStore : DataModelStore
    {
        private readonly string server;
        private readonly string database;

        public SSASDataModelStore(string server, string database)
        {
            // server can be e.g. "localhost:54287"
            this.server = server;
            this.database = database;
        }

        public Database Read()
        {
            var s = new Server();
            s.Connect($"Data source={server}");
            var info = s.ConnectionInfo;

            if (database != null)
                return s.Databases[database];
            else
                return s.Databases[0];
        }

        public void Save(Database model)
        {
            // todo: implement
            // - start a local ssas server that I have rights to (docker or local)
            // - test save (if the model is already connected to the server/datase that were specified in the ctor)
            // - if the server is empty, or the server/db are not the same as passed in ctor, create a new db
            //      a) use the update method with UpdateMode.Create (or use UpdateOrCreate with the correct server) https://docs.microsoft.com/en-us/analysis-services/tom/create-and-deploy-an-empty-database-analysis-services-amo-tom?view=asallproducts-allversions
            //      b) see decomiped TabularEditor code: TabularEditor.TOMWrapper.Utils.TabularDeployer (TOMWrapper14.dll) - it uses tsml to create the model

            if (model.Server != null)
            {
                if (model.Server.ConnectionInfo.Server == server)
                { }
            }
        }
    }
}
