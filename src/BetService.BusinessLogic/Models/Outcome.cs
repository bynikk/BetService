using BetService.BusinessLogic.Enums;

namespace BetService.BusinessLogic.Models
{
    public class Outcome
    {
        public Outcome()
        {
            Coefficients = new();
        }

        public Guid Id { get; set; }

        public OutcomeType OutcomeType { get; set; }

        public OutcomeStatusType StatusType { get; set; }

        public List<Coefficient> Coefficients { get; set; }
    }
}
