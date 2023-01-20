using BetService.BusinessLogic.Contracts.Services;
using BetService.BusinessLogic.Services;
using BetService.DataAccess.Mappings;
using BetService.Grpc.Infastructure.Mappings;

using BusinessModels = BetService.BusinessLogic.Models;

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

            services.AddScoped<ICompetitionService<BusinessModels.Competitions.CompetitionDota2>, CompetitionDota2Service>();

            return services;
        }

    }
}
