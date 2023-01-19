using AutoMapper;
using BetService.BusinessLogic.Contracts.Repositories;
using Grpc.Core;

using BussinessModels = BetService.BusinessLogic.Models;

namespace BetService.Grpc.Services
{
    public class BetService : Grpc.BetService.BetServiceBase
    {
        private readonly ICompetitionRepository<BussinessModels.Competitions.CompetitionCS> _competitionRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<BetService> _logger;

        public BetService(
            ILogger<BetService> logger,
            ICompetitionRepository<BussinessModels.Competitions.CompetitionCS> competitionRepository,
            IMapper mapper)
        {
            _logger = logger;
            _competitionRepository = competitionRepository;
            _mapper = mapper;
        }

        public override async Task<CreateCompetitionResponse> CreateCompetition(CreateCompetitionRequest request, ServerCallContext context)
        {
            var competition = _mapper.Map<BussinessModels.Competitions.CompetitionCS>(request.Competition);
            await _competitionRepository.CreateCompetition(
                competition
                , context.CancellationToken);
            return new CreateCompetitionResponse();
        }
    }
}
