using MongoDB.Bson;
using MongoDB.Driver;

namespace PLM_API.Infrastructure.Mongo
{
    public class MongoRepository : IMongoRepository
    {
        private readonly IMongoDbContext _context;
        public MongoRepository(IMongoDbContext context) => _context = context;

        public IMongoCollection<T> Collection<T>(string name) => _context.GetCollection<T>(name);

        public async Task<T?> FindByIdAsync<T>(string collectionName, string id)
        {
            var col = Collection<T>(collectionName);
            var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
            return await col.Find(filter).FirstOrDefaultAsync();
        }

        public async Task InsertOneAsync<T>(string collectionName, T entity)
        {
            var col = Collection<T>(collectionName);
            await col.InsertOneAsync(entity);
        }

        public async Task ReplaceOneAsync<T>(string collectionName, string id, T entity)
        {
            var col = Collection<T>(collectionName);
            var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
            await col.ReplaceOneAsync(filter, entity);
        }

        public async Task DeleteByIdAsync<T>(string collectionName, string id)
        {
            var col = Collection<T>(collectionName);
            var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
            await col.DeleteOneAsync(filter);
        }

        public async Task<List<T>> FindAsync<T>(string collectionName, FilterDefinition<T> filter)
        {
            var col = Collection<T>(collectionName);
            return await col.Find(filter).ToListAsync();
        }
    }
}
