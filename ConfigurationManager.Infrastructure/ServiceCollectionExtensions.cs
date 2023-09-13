using ConfigurationManager.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace ConfigurationManager.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddTransient<IConfigurationRepository, ConfigurationRepositroy>();

            serviceCollection.AddSingleton<IConnectionMultiplexer>(opt =>
            ConnectionMultiplexer.Connect(configuration["DatabaseSettings:ConnectionString"]));

            // ConnectionMultiplexer.Connect(configuration["DatabaseSettings:ConnectionString"]);
            return serviceCollection;
        }
    }
}
