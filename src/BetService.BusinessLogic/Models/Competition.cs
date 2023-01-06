using BetService.BusinessLogic.Enums;

namespace BetService.BusinessLogic.Models
{
    public class Сompetition
    {
        public Guid Id { get; set; }

        public Guid СompetitionId { get; set; }

        public CompetitionType CompetitionType { get; set; }
    }
}
