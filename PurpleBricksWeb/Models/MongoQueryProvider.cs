using MongoDB.Driver;
using System;
using System.Configuration;
using System.Security.Authentication;

namespace PurpleBricksWeb.Models
{
    public class MongoQueryProvider : IDisposable
    {
        private bool disposed;

        public IMongoDatabase DB { get; set; }

        public MongoQueryProvider()
        {
            string userName = ConfigurationManager.AppSettings["CosmosDB.UserName"];
            string host = ConfigurationManager.AppSettings["CosmosDB.Host"];
            string password = ConfigurationManager.AppSettings["CosmosDB.Password"];
            string dbName = ConfigurationManager.AppSettings["CosmosDB.Database"];

            MongoClientSettings settings = new MongoClientSettings();
            settings.Server = new MongoServerAddress(host, 10255);
            settings.UseSsl = true;
            settings.SslSettings = new SslSettings();
            settings.SslSettings.EnabledSslProtocols = SslProtocols.Tls12;

            MongoIdentity identity = new MongoInternalIdentity(dbName, userName);
            MongoIdentityEvidence evidence = new PasswordEvidence(password);

            settings.Credential = new MongoCredential("SCRAM-SHA-1", identity, evidence);

            MongoClient client = new MongoClient(settings);
            DB = client.GetDatabase(dbName);
        }

        #region IDisposable

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                }
            }

            this.disposed = true;
        }

        # endregion
    }
}