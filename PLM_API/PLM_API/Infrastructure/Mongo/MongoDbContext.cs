using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace PLM_API.Infrastructure.Mongo
{
    public class MongoDbContext : IMongoDbContext
    {
        public IMongoDatabase Database { get; }

        public MongoDbContext(IOptions<MongoSettings> settings)
        {
            var s = settings.Value;
            if (string.IsNullOrEmpty(s.ConnectionString)) throw new ArgumentException("Mongo connection string is not configured.");
            if (string.IsNullOrEmpty(s.Database)) throw new ArgumentException("Mongo database is not configured.");

            var client = new MongoClient(s.ConnectionString);
            Database = client.GetDatabase(s.Database);
        }

        public IMongoCollection<T> GetCollection<T>(string name) => Database.GetCollection<T>(name);
    }
}
