using AutoMapper;
using BetService.BusinessLogic.Contracts.Providers;
using BetService.BusinessLogic.Enums;
using BetService.BusinessLogic.Models.Competitions;
using BetService.DataAccess.MongoEntities.CompetitionEntities;
using MongoDB.Driver;

namespace BetService.DataAccess.Providers
{
    public class CompetitionCSProvider : ICompetitionProvider<CompetitionCS>
    {
        private readonly IMongoCollection<CompetitionCSEntity> _collection;
        private readonly IMapper _mapper;

        public CompetitionCSProvider(
            IMongoCollection<CompetitionCSEntity> collection,
            IMapper mapper)
        {
            _collection = collection;
            _mapper = mapper;
        }

        public async Task<List<CompetitionCS>> GetCompetitionsByStatusType(
            CompetitionStatusType competitionStatusType,
            int page,
            int size,
            CancellationToken token)
        {
            var builder = Builders<CompetitionCSEntity>.Filter;
            var quaryCompetitionType = builder.Eq(x => x.CompetitionType, CompetitionType.EsportCS);
            var quaryStatusType = builder.Eq(x => x.CompetitionType, CompetitionType.EsportCS);

            var query = builder.And(quaryCompetitionType, quaryStatusType);
            var entities = await _collection.Find(query).ToListAsync(token);

            var competitions = _mapper.Map<List<CompetitionCS>>(entities);

            return competitions;

        }
    }
}
