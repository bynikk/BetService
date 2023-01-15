
using BetService.BusinessLogic.Enums;

namespace BetService.BusinessLogic.Models
{
    public class OutcomeGroup
    {
        public OutcomeGroup()
        {
            OutcomeIds = new();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public OutcomeGroupType OutcomeGroupType { get; set; }

        public List<Guid> OutcomeIds { get; set; }
    }
}
