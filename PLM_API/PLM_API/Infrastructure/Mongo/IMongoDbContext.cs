using MongoDB.Driver;

namespace PLM_API.Infrastructure.Mongo
{
    public interface IMongoDbContext
    {
        IMongoDatabase Database { get; }
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
