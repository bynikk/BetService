using AutoMapper;
using BetService.BusinessLogic.Contracts.Providers;
using BetService.BusinessLogic.Enums;
using BetService.BusinessLogic.Models.Competitions;
using BetService.DataAccess.MongoEntities.CompetitionEntities;
using MongoDB.Driver;

namespace BetService.DataAccess.Providers
{
    public class CompetitionDota2Provider : ICompetitionProvider<CompetitionDota2>
    {
        private readonly IMongoCollection<CompetitionDota2Entity> _collection;
        private readonly IMapper _mapper;

        public CompetitionDota2Provider(
            IMongoCollection<CompetitionDota2Entity> collection,
            IMapper mapper)
        {
            _collection = collection;
            _mapper = mapper;
        }

        public async Task<CompetitionDota2> GetCompetitionById(Guid Id, CancellationToken token)
        {
            var item = await _collection.FindAsync(x => x.Id == Id.ToString());

            return _mapper.Map<CompetitionDota2>(item);
        }

        public async Task<List<CompetitionDota2>> GetCompetitionsByStatusType(
            CompetitionStatusType competitionStatusType,
            int page,
            int pageSize,
            CancellationToken token)
        {
            var builder = Builders<CompetitionDota2Entity>.Filter;
            var quaryCompetitionType = builder.Eq(x => x.Type, CompetitionType.EsportDota2);
            var quaryStatusType = builder.Eq(x => x.StatusType, competitionStatusType);

            var query = builder.And(quaryCompetitionType, quaryStatusType);
            var entities = await _collection
                .Find(query)
                .Skip((page - 1) * pageSize)
                .Limit(pageSize)
                .ToListAsync(token);

            var items = _mapper.Map<List<CompetitionDota2>>(entities);

            return items;

        }
    }
}
