using AutoMapper;
using BetService.BusinessLogic.Contracts.Repositories;
using BetService.BusinessLogic.Models.Competitions;
using BetService.DataAccess.MongoEntities.CompetitionEntities;
using MongoDB.Driver;

namespace BetService.DataAccess.Repositories
{
    public class CompetitionCSRepository : ICompetitionRepository<CompetitionCS>
    {
        private readonly IMongoCollection<CompetitionCSEntity> _collection;
        private readonly IMapper _mapper;

        private static readonly InsertOneOptions _defaultInsertOneOption = new();

        public CompetitionCSRepository(
            IMongoCollection<CompetitionCSEntity> collection,
            IMapper mapper)
        {
            _collection = collection;
            _mapper = mapper;
        }

        public Task CreateCompetition(CompetitionCS item, CancellationToken cancellationToken)
        {
            var itemEntity = _mapper.Map<CompetitionCSEntity>(item);

            return _collection.InsertOneAsync(itemEntity, _defaultInsertOneOption, cancellationToken);
        }

        public Task DeleteCompetitionById(Guid Id, CancellationToken cancellationToken)
        {
            var builder = Builders<CompetitionCSEntity>.Filter;
            var quaryId = builder.Eq(x => x.Id, Id.ToString());

            return _collection.DeleteOneAsync(quaryId, cancellationToken);
        }

        public Task UpdateCompetitionById(CompetitionCS item, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
