using MongoDB.Bson;
using MongoDB.Driver;
using PurpleBricksLibrary;
using PurpleBricksWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PurpleBricksWeb
{
    public class UnitPriceDAL : IDisposable
    {
        private bool disposed;
        public UnitPriceDAL(){
            AllPrices = new List<UnitPrice>();
        }

        public static List<UnitPrice> AllPrices;

        public List<UnitPrice> GetAllPrices()
        {
            using (var session = new MongoSession<UnitPrice>())
            {
                if (AllPrices != null && AllPrices.Count() > 0)
                    return AllPrices;

                try
                {
                    var collection = session.FindAll<UnitPrice>();
                    AllPrices = collection.Find(new BsonDocument()).ToList();
                }
                catch(TimeoutException) { }
                return AllPrices;
            }
        }

        /// <summary>
        /// Retrieve unit price for a given state and board size.
        /// </summary>
        public decimal GetUnitPrice(string state, BoardSize size)
        {
            decimal price = 0m;
            UnitPrice result = GetAllPrices().Where(p => p.BSize == size && p.State == state).FirstOrDefault();
            if(result != null)
                price = result.Price;

            return price;
        }

        # region IDisposable

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
