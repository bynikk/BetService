using BetService.BusinessLogic.Enums;

namespace BetService.BusinessLogic.Models
{
    public class Сompetition
    {
        public Сompetition()
        {
            AvailableOutcomeIds = new();
            Teams = new();
        }

        public Guid Id { get; set; }

        public CompetitionType CompetitionType { get; set; }

        public DateTime StartTime { get; set; }

        public List<Guid> Teams { get; set; }

        public List<Guid> AvailableOutcomeIds { get; set; }
    }
}
