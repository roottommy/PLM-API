using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PLM_API.Infrastructure.Mongo;

namespace PLM_API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMongo(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoSettings>(configuration.GetSection("Mongo"));
            services.AddSingleton<IMongoDbContext, MongoDbContext>();
            services.AddScoped<IMongoRepository, MongoRepository>();
            return services;
        }
    }
}
