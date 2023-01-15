using BetService.BusinessLogic.Enums;

namespace BetService.BusinessLogic.Models
{
    public class Outcome
    {
        public Guid Id { get; set; }

        public Guid CoefficientId { get; set; }

        public string Description { get; set; }
    }
}
