using BetService.BusinessLogic.Enums;
using BetService.BusinessLogic.Models.Competitions;

namespace BetService.BusinessLogic.Contracts.Providers
{
    public interface ICompetitionProvider<T> where T : class
    {
        Task<List<CompetitionDota2>> GetCompetitions(
            int page,
            int pageSize,
            CancellationToken token);

        Task<T> GetCompetitionById(Guid Id, CancellationToken token);
    }
}
