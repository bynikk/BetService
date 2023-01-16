using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BetService.DataAccess
{
    public static class DataAccessServicesExtensions
    {
        /// <summary>Register the mongo database context.</summary>
        /// <param name="services">The services collection.</param>
        /// <returns>
        ///   The services collection.
        /// </returns>
        public static IServiceCollection AddMongoDbContext(this IServiceCollection services)
        {
            services.AddScoped<BetDbContext>()
                    .AddScoped(serviceProvider =>
                serviceProvider.GetRequiredService<BetDbContext>().OutcomeGroupCollection)
                    .AddScoped(serviceProvider =>
                serviceProvider.GetRequiredService<BetDbContext>().BetCollection)
                    .AddScoped(serviceProvider =>
                serviceProvider.GetRequiredService<BetDbContext>().OutcomeGroupCollection)
                    .AddScoped(serviceProvider =>
                serviceProvider.GetRequiredService<BetDbContext>().TeamCollection);

            services.AddSingleton(serviceProvider =>
            {
                var options = serviceProvider.GetRequiredService<IOptions<BetDbConfig>>();
                var client = new MongoClient(options.Value.ConnectionString);

                return client.GetDatabase(options.Value.DatabaseName);
            });

            return services;
        }

        /// <summary>Register the mongo repositories in service collection.</summary>
        /// <param name="services">The services collection.</param>
        /// <returns>
        ///   The services collection.
        /// </returns>
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services;
        }

        /// <summary>Register the mongo providers in service collection.</summary>
        /// <param name="services">The services collection.</param>
        /// <returns>
        ///   The services collection.
        /// </returns>
        public static IServiceCollection AddProviders(this IServiceCollection services)
        {
            return services;
        }


    }
}
