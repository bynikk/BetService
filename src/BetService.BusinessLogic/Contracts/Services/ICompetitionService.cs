using BetService.BusinessLogic.Models.Competitions;

namespace BetService.BusinessLogic.Contracts.Services
{
    public interface ICompetitionService<T> where T : class
    {
        Task CreateCompetition(T item, CancellationToken cancellationToken);

        Task DeleteCompetitionById(Guid Id, CancellationToken cancellationToken);

        Task UpdateCompetition(T item, CancellationToken cancellationToken);

        Task<List<CompetitionDota2>> GetCompetitions(
            int page,
            int pageSize,
            CancellationToken token);

        Task<T> GetCompetitionById(Guid Id, CancellationToken token);
    }
}
