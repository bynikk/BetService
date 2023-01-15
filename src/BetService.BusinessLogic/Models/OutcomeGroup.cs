
using BetService.BusinessLogic.Enums;

namespace BetService.BusinessLogic.Models
{
    public class OutcomeGroup
    {
        public OutcomeGroup()
        {
            Outcomes = new();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public OutcomeGroupType OutcomeGroupType { get; set; }

        public List<Outcome> Outcomes { get; set; }
    }
}
