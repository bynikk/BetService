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
            CreateMap<CoefficientEntity, Coefficient>()
                .ReverseMap();
            CreateMap<CoefficientGroupEntity, CoefficientGroup>()
                .ReverseMap();
            CreateMap<CoefficientEntity, Coefficient>()
                .ReverseMap();
            CreateMap<CompetitionDota2Entity, CompetitionDota2>()
               .ReverseMap();
            CreateMap<Guid, string>()
                .ConvertUsing(s => s.ToString());
            CreateMap<string, Guid>()
                .ConvertUsing(s => Guid.Parse(s));
        }
    }

}
