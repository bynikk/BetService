using BetService.BusinessLogic.Enums;

namespace BetService.BusinessLogic.Models
{
    public class Team
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public CompetitionType CompetitionType { get; set; }

        public string logo_img { get; set; }
    }
}
