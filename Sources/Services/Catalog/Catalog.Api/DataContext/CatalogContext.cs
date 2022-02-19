using Catalog.Api.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.Api.DataContext
{
    public class CatalogContext:ICatalogContext
    {
        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("MongoDB:ConnectionURI"));
            var database = client.GetDatabase(configuration.GetValue<string>("MongoDB:DataBase"));

            Products = database.GetCollection<Product>(configuration.GetValue<string>("MongoDB:CollectionName"));
        }
        public IMongoCollection<Product> Products { get; }
    }
}
