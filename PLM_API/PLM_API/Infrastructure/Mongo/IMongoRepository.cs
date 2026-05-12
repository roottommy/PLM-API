using MongoDB.Driver;

namespace PLM_API.Infrastructure.Mongo
{
    public interface IMongoRepository
    {
        IMongoCollection<T> Collection<T>(string name);
        Task<T?> FindByIdAsync<T>(string collectionName, string id);
        Task InsertOneAsync<T>(string collectionName, T entity);
        Task ReplaceOneAsync<T>(string collectionName, string id, T entity);
        Task DeleteByIdAsync<T>(string collectionName, string id);
        Task<List<T>> FindAsync<T>(string collectionName, FilterDefinition<T> filter);
    }
}
