using BetService.BusinessLogic.Contracts.Providers;
using BetService.BusinessLogic.Models.Competitions;
using Grpc.Core;

namespace BetService.Grpc.Services
{
    public class BetService : Grpc.BetService.BetServiceBase
    {
        private readonly ICompetitionProvider<CompetitionCS> _competitionProvider;

        public BetService(ICompetitionProvider<CompetitionCS> competitionProvider)
        {
            _competitionProvider = competitionProvider;
        }

        public override async Task<GetCompetitionsResponse> GetCompetitions(GetCompetitionsRequest request, ServerCallContext context)
        {
            var a = await _competitionProvider.GetCompetitionsByStatusType(BusinessLogic.Enums.CompetitionStatusType.Live, 4, 4, CancellationToken.None);

            return new GetCompetitionsResponse();
        }
    }
}
