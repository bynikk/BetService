using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BetService.BusinessLogic.Models;
using BetService.BusinessLogic.Models.Competitions;
using BetService.DataAccess.MongoEntities;
using BetService.DataAccess.MongoEntities.CompetitionEntities;

namespace BetService.DataAccess.Mappings
{
    public class DataAccessProfile : Profile
    {
        /// <summary>Initializes a new instance of the <see cref="DataAccessProfile" /> class.</summary>
        public DataAccessProfile()
        {
            CreateMap<OutcomeEntity, Outcome>()
                .ReverseMap();
            CreateMap<OutcomeGroupEntity, OutcomeGroup>()
                .ReverseMap();
            CreateMap<TeamEntity, Team>()
                .ReverseMap();
            CreateMap<CoefficientEntity, Coefficient>()
                .ReverseMap();
            CreateMap<CompetitionDota2Entity, CompetitionDota2>()
               .ReverseMap();
            CreateMap<string, Guid>()
                .ConvertUsing((x, res) => res = Guid.TryParse(x, out var id) ? id : Guid.Empty);
            CreateMap<Guid?, string>()
                .ConvertUsing((x, res) => res = x?.ToString() ?? string.Empty);

        }
    }

}
