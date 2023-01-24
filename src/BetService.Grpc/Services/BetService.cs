using AutoMapper;
using BetService.BusinessLogic.Contracts.Providers;
using BetService.BusinessLogic.Contracts.Repositories;
using Grpc.Core;

using BussinessModels = BetService.BusinessLogic.Models;
using BussinessEnums = BetService.BusinessLogic.Enums;
using BetService.BusinessLogic.Contracts.Services;

namespace BetService.Grpc.Services
{
    public class BetService : Grpc.BetService.BetServiceBase
    {
        private readonly IMapper _mapper;
        private readonly ICoefficientRepository _coefficientRepository;
        private readonly ILogger<BetService> _logger;
        private readonly ICompetitionService<BussinessModels.Competitions.CompetitionDota2> _competitionDota2Service;

        public BetService(
            ILogger<BetService> logger,
            ICompetitionService<BussinessModels.Competitions.CompetitionDota2> competitionDota2Service,
            IMapper mapper, ICoefficientRepository coefficientRepository)
        {
            _logger = logger;
            _competitionDota2Service = competitionDota2Service;
            _mapper = mapper;
            _coefficientRepository = coefficientRepository;
        }

        public override async Task<CreateCompetitionDota2Response> CreateCompetitionDota2(CreateCompetitionDota2Request request, ServerCallContext context)
        {
            var competition = _mapper.Map<BussinessModels.Competitions.CompetitionDota2>(request.CompetitionDota2);
            await _competitionDota2Service.CreateCompetition(
                competition
                , context.CancellationToken);

            return new CreateCompetitionDota2Response();
        }

        public override async Task<GetCompetitionsDota2Response> GetCompetitionsDota2(GetCompetitionsDota2Request request, ServerCallContext context)
        {
            var token = context.CancellationToken;

            var competitions = await _competitionDota2Service.GetCompetitions(
                request.Page,
                request.PageSize,
                token);

            var response = new GetCompetitionsDota2Response();
            var grpcCompetitions = _mapper.Map<IEnumerable<CompetitionDota2>>(competitions);

            response.CompetitionsDota2.AddRange(grpcCompetitions);
            await _coefficientRepository.DepositAmountById(
                new Guid("b350c9fd-3632-4b0a-b5cb-66e41d530f55"),
                new Guid("3c203bd7-2d7e-4937-a82a-e451cedf2ba8"),
                10,
                token);
            return response;
        }

        public override async Task<UpdateCompetitionDota2Response> UpdateCompetitionDota2(UpdateCompetitionDota2Request request, ServerCallContext context)
        {
            var token = context.CancellationToken;

            var competitionForUpdate = _mapper.Map<BussinessModels.Competitions.CompetitionDota2>(request.CompetitionDota2);

            await _competitionDota2Service.UpdateCompetition(competitionForUpdate, token);

            return new UpdateCompetitionDota2Response();
        }
    }
}
