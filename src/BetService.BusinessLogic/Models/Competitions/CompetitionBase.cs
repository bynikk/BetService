using BetService.BusinessLogic.Enums;

namespace BetService.BusinessLogic.Models.Competitions
{
    public abstract class CompetitionBase
    {
        public CompetitionBase()
        {
            CoefficientGroups = new();
        }

        public Guid Id { get; set; }

        public CompetitionStatusType StatusType { get; set; }

        public CompetitionType Type { get; set; }

        public DateTime StartTime { get; set; }

        public List<CoefficientGroup> CoefficientGroups { get; set; }
    }
}
