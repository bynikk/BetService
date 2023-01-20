using AutoMapper;
using BetService.BusinessLogic.Contracts.Providers;
using BetService.BusinessLogic.Contracts.Repositories;
using Grpc.Core;

using BussinessModels = BetService.BusinessLogic.Models;
using BussinessEnums = BetService.BusinessLogic.Enums;

namespace BetService.Grpc.Services
{
    public class BetService : Grpc.BetService.BetServiceBase
    {
        private readonly ICompetitionRepository<BussinessModels.Competitions.CompetitionDota2> _competitionDota2Repository;
        private readonly ICompetitionProvider<BussinessModels.Competitions.CompetitionDota2> _competitionDota2Provider;
        private readonly IMapper _mapper;
        private readonly ILogger<BetService> _logger;

        public BetService(
            ILogger<BetService> logger,
            ICompetitionRepository<BussinessModels.Competitions.CompetitionDota2> competitionDota2Repository,
            ICompetitionProvider<BussinessModels.Competitions.CompetitionDota2> competitionDota2Provider,
            IMapper mapper)
        {
            _logger = logger;
            _competitionDota2Repository = competitionDota2Repository;
            _competitionDota2Provider = competitionDota2Provider;
            _mapper = mapper;
        }

        public override async Task<CreateCompetitionDota2Response> CreateCompetitionDota2(CreateCompetitionDota2Request request, ServerCallContext context)
        {
            var competition = _mapper.Map<BussinessModels.Competitions.CompetitionDota2>(request.CompetitionDota2);
            await _competitionDota2Repository.CreateCompetition(
                competition
                , context.CancellationToken);

            return new CreateCompetitionDota2Response();
        }

        public override async Task<GetCompetitionsDota2Response> GetCompetitionsDota2(GetCompetitionsDota2Request request, ServerCallContext context)
        {
            var token = context.CancellationToken;

            var competitions = await _competitionDota2Provider.GetCompetitions(
                request.Page,
                request.PageSize,
                token);

            var response = new GetCompetitionsDota2Response();
            var grpcCompetitions = _mapper.Map<IEnumerable<CompetitionDota2>>(competitions);

            response.CompetitionsDota2.AddRange(grpcCompetitions);

            return response;
        }

        public override async Task<UpdateCompetitionDota2Response> UpdateCompetitionDota2(UpdateCompetitionDota2Request request, ServerCallContext context)
        {
            var token = context.CancellationToken;

            var competitionForUpdate = _mapper.Map<BussinessModels.Competitions.CompetitionDota2>(request.CompetitionDota2);

            await _competitionDota2Repository.UpdateCompetition(competitionForUpdate, token);

            return new UpdateCompetitionDota2Response();
        }
    }
}
