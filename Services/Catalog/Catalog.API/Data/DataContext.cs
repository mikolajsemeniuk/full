using Catalog.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class DataContext
    {
        public IMongoCollection<Product> Products { get; init; }

        public DataContext(IConfiguration config)
        {
            var client = new MongoClient(config["MongoDbSettings:ConnectionString"]);
            var database = client.GetDatabase(config["MongoDbSettings:Collection"]);

            Products = database.GetCollection<Product>("Products");
        }
    }
}