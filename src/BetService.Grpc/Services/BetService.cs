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
        private readonly ILogger<BetService> _logger;
        private readonly ICompetitionService<BussinessModels.Competitions.CompetitionDota2> _competitionDota2Service;
        private readonly ICoefficientRepository _coefficientRepository;

        public BetService(
            ILogger<BetService> logger,
            ICompetitionService<BussinessModels.Competitions.CompetitionDota2> competitionDota2Service,
            ICoefficientRepository coefficientRepository,
            IMapper mapper)
        {
            _logger = logger;
            _competitionDota2Service = competitionDota2Service;
            _coefficientRepository = coefficientRepository;
            _mapper = mapper;
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
  
            return response;
        }

        public override async Task<UpdateCompetitionDota2Response> UpdateCompetitionDota2(UpdateCompetitionDota2Request request, ServerCallContext context)
        {
            var token = context.CancellationToken;

            var competitionForUpdate = _mapper.Map<BussinessModels.Competitions.CompetitionDota2>(request.CompetitionDota2);

            await _competitionDota2Service.UpdateCompetition(competitionForUpdate, token);

            return new UpdateCompetitionDota2Response();
        }

        public override async Task<DepositToCoefficientByIdResponse> DepositToCoefficientById(DepositToCoefficientByIdRequest request, ServerCallContext context)
        {
            var token = context.CancellationToken;
        
            var competitionId = _mapper.Map<Guid>(request.CompetitionId);
            var coefficientId = _mapper.Map<Guid>(request.CoefficientId);
        
            await _coefficientRepository.DepositAmountById(competitionId, coefficientId, request.Amount, token);
        
            var response = new DepositToCoefficientByIdResponse()
            {
                Rate = 0,
            };
        
            return response;
        }
    }
}
