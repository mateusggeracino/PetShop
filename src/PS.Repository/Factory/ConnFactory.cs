using System.Data;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace PS.Repository.Factory
{
    public sealed class ConnFactory
    {
        private readonly string _connectionString;
        public ConnFactory(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }
        public IMongoClient GetClient()
        {
            var client = new MongoClient(_connectionString);

            return client;
        }

        public IMongoDatabase GetDataBase(string databaseName)
        {
            var client = GetClient();
            var database = client.GetDatabase(databaseName);

            return database;
        }
    }
}