using BetService.BusinessLogic.Enums;

namespace BetService.BusinessLogic.Models
{
    public class Outcome
    {
        public Guid Id { get; set; }

        public Coefficient Coefficient { get; set; }

        public string Description { get; set; }
    }
}
