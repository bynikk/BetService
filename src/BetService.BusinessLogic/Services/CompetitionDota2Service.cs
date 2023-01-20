using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetService.BusinessLogic.Contracts.Providers;
using BetService.BusinessLogic.Contracts.Repositories;
using BetService.BusinessLogic.Contracts.Services;
using BetService.BusinessLogic.Models.Competitions;

namespace BetService.BusinessLogic.Services
{
    public class CompetitionDota2Service : ICompetitionService<CompetitionDota2>
    {
        private readonly ICompetitionProvider<CompetitionDota2> _provider;
        private readonly ICompetitionRepository<CompetitionDota2> _repository;

        public CompetitionDota2Service(
            ICompetitionProvider<CompetitionDota2> provider,
            ICompetitionRepository<CompetitionDota2> repository)
        {
            _provider = provider;
            _repository = repository;
        }

        public Task CreateCompetition(CompetitionDota2 item, CancellationToken cancellationToken)
        {
            return _repository.CreateCompetition(item, cancellationToken);
        }

        public Task DeleteCompetitionById(Guid Id, CancellationToken cancellationToken)
        {
            return _repository.DeleteCompetitionById(Id, cancellationToken);
        }

        public Task<CompetitionDota2> GetCompetitionById(Guid Id, CancellationToken token)
        {
            return _provider.GetCompetitionById(Id, token);
        }

        public Task<List<CompetitionDota2>> GetCompetitions(int page, int pageSize, CancellationToken token)
        {
            return _provider.GetCompetitions(page, pageSize, token);
        }

        public Task UpdateCompetition(CompetitionDota2 item, CancellationToken cancellationToken)
        {
            return _repository.UpdateCompetition(item, cancellationToken);
        }
    }
}
