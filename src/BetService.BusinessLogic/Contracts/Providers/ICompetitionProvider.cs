using BetService.BusinessLogic.Enums;

namespace BetService.BusinessLogic.Contracts.Providers
{
    public interface ICompetitionProvider<T> where T : class
    {
        Task<List<T>> GetCompetitionsByStatusType(
            CompetitionStatusType competitionStatusType,
            int page,
            int size,
            CancellationToken token);

        Task<T> GetCompetitionById(Guid Id, CancellationToken token);
    }
}
