using BetService.BusinessLogic.Contracts.Providers;
using BetService.BusinessLogic.Models.Competitions;
using BetService.Grpc;
using Grpc.Core;

namespace BetService.Grpc.Services
{
    public class BetService : Grpc.BetService.BetServiceBase
    {
        private readonly ICompetitionProvider<CompetitionCS> _competitionProvider;
        private readonly ILogger<BetService> _logger;

        public BetService(ILogger<BetService> logger, ICompetitionProvider<CompetitionCS> competitionProvider)
        {
            _logger = logger;
            _competitionProvider = competitionProvider;
        }

        public override async Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            var a = await _competitionProvider.GetCompetitionsByStatusType(BusinessLogic.Enums.CompetitionStatusType.Live, 4, 4, CancellationToken.None);
            return new HelloReply
            {
                Message = "Hello " + request.Name
            };
        }
    }
}
