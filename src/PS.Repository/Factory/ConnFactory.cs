using MongoDB.Driver;

namespace PS.Repository.Factory
{
    public class ConnFactory
    {
        private readonly string _connectionString;
        public ConnFactory(string connectionString)
        {
            _connectionString = connectionString;
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