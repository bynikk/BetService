namespace BetService.DataAccess
{
    public class BetDbConfig
    {
        public string? ConnectionString { get; set; }

        public string? DatabaseName { get; set; }

        public string? CompetitionsCollectionName { get; set; }

        public string? TeamsCollectionName { get; set; }

        public string? BetCollectionName { get; set; }

        public string? OutcomeGroupCollectionName { get; set; }
    }
}
