using ConfigurationManager.Application;
using ConfigurationManager.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace ConfigurationManager
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigurationManager(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddInfrastructure(configuration);
            serviceCollection.AddApplication(configuration);
            //serviceCollection.AddSingleton<IConnectionMultiplexer>(opt=>
            //ConnectionMultiplexer.Connect(configuration.GetConnectionString("RedisConnection")));
            return serviceCollection;
        }
    }
}
