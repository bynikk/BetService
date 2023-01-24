namespace BetService.BusinessLogic.Contracts.Repositories
{
    public interface ICoefficientRepository
    {
        Task DepositAmountById(Guid competitionId, Guid CoefficientId, double amount, CancellationToken token);
    }
}
