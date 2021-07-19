using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoRepositoryPattern.Models;

namespace MongoRepositoryPattern.Context
{
    public class MongoContext : IMongoContext
    {
        private readonly IMongoDatabase _database;
        private readonly MongoClient _mongoClient;
        private readonly IClientSessionHandle _clientSession;

        public MongoContext(IOptions<Settings> configuration)
        {
            _mongoClient = new MongoClient(configuration.Value.ConnectionString);
            _database = _mongoClient.GetDatabase(configuration.Value.Database);
        }

        public IMongoCollection<TEntity> GetCollection<TEntity>(string name)
        {
            return _database.GetCollection<TEntity>(name);
        }
    }
}
