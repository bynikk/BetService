using BetService.BusinessLogic.Models;

namespace BetService.BusinessLogic.Contracts.Providers
{
    public interface ICoefficientProvider
    {
        Task<Coefficient> GetCoefficient(Guid competitionId, Guid CoefficientId, CancellationToken token);
    }
}
