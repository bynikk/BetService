using BetService.DataAccess.Mappings;
using BetService.Grpc.Infastructure.Mappings;

namespace BetService.Grpc.Infastructure.Configurations
{
    public static partial class AppConfigurations
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                config.AddProfile<DataAccessProfile>();
                config.AddProfile<BetServiceProfile>();
            });

            return services;
        }

    }
}
