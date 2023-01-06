using BetService.BusinessLogic.Enums;

namespace BetService.BusinessLogic.Models.Competitions
{
    public class EsportСompetition
    {
        public EsportСompetition()
        {
            AvailableBetsIds = new();
        }

        public Guid Id { get; set; }

        public EsportType EsportType { get; set; }

        public Guid Team1Id { get; set; }

        public Guid Team2Id { get; set; }

        public DateTime StartTime { get; set; }

        public List<Guid> AvailableBetsIds { get; set; }
    }
}
