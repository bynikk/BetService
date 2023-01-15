namespace BetService.BusinessLogic.Models
{
    public class Bet
    {
        public Guid Id { get; set; }

        public Guid ProfileId { get; set; }

        public Guid OutcomeId { get; set; }

        public Guid CoefficientId { get; set; }

        public double Rate { get; set; }

        public double Amount { get; set; }
    }
}
