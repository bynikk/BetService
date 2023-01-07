namespace BetService.DataAccess
{
    public class BetDbConfig
    {
        public string? ConnectionString { get; set; }

        public string? DatabaseName { get; set; }

        public string? CompetitionsContainer { get; set; }

        public string? TeamsContainer { get; set; }

        public string? BetsContainer { get; set; }

        public string? BettorsContainer { get; set; }

        public string? OutcomesContainer { get; set; }

        public string? CoefficientsContainer { get; set; }
    }
}
