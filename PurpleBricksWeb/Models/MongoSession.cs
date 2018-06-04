using MongoDB.Driver;
using System;

namespace PurpleBricksWeb.Models
{
    public class MongoSession<TEntity> : IDisposable
    {
        private MongoQueryProvider provider;
        public MongoSession()
        {
            this.provider = new MongoQueryProvider();
        }

        public MongoQueryProvider Provider
        {
            get { return this.provider; }
        }

        public IMongoCollection<T> FindAll<T>() where T : class, new()
        {
            return this.Provider.DB.GetCollection<T>(typeof(T).Name);
        }

        public void Add<T>(T item) where T : class, new()
        {
            this.Provider.DB.GetCollection<T>(typeof(T).Name).InsertOne(item);
        }

        public void Dispose()
        {
            this.provider.Dispose();
        }

        public void Delete<T>(FilterDefinition<T> filter) where T : class, new()
        {
            this.provider.DB.GetCollection<T>(typeof(T).Name).DeleteOne(filter);
        }

        public void Drop<T>()
        {
            this.provider.DB.DropCollection(typeof(T).Name);
        }

        public ReplaceOneResult Save<T>(FilterDefinition<T> filter, T item) where T : class, new()
        {
            return this.provider.DB.GetCollection<T>(typeof(T).Name).ReplaceOne(filter, item);
        }
    }
}