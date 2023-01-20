using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using BusinessModels = BetService.BusinessLogic;

namespace BetService.Grpc.Infastructure.Mappings
{
    public class BetServiceProfile : Profile
    {
        public BetServiceProfile()
        {
            CreateMap<DateTime, Timestamp>()
                .ConvertUsing(x => Timestamp.FromDateTime(x));
            CreateMap<Timestamp, DateTime>()
                .ConvertUsing(x => x.ToDateTime());

            CreateMap<CompetitionCS, BusinessModels.Models.Competitions.CompetitionDota2>()
                .ReverseMap();
            CreateMap<Coefficient, BusinessModels.Models.Coefficient>()
                .ReverseMap();
            CreateMap<Outcome, BusinessModels.Models.Outcome>()
                .ReverseMap();
            CreateMap<OutcomeGroup, BusinessModels.Models.OutcomeGroup>()
                .ReverseMap();

            CreateMap<CompetitionStatusType, BusinessModels.Enums.CompetitionStatusType>()
                .ReverseMap();
            CreateMap<CompetitionType, BusinessModels.Enums.CompetitionType>()
                .ReverseMap();
            CreateMap<OutcomeGroupType, BusinessModels.Enums.OutcomeGroupType>()
                .ReverseMap();
            CreateMap<CoefficientStatusType, BusinessModels.Enums.CoefficientStatusType>()
                .ReverseMap();
        }

    }
}
