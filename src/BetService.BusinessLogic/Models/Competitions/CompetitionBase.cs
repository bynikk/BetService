﻿using BetService.BusinessLogic.Enums;

namespace BetService.BusinessLogic.Models.Competitions
{
    public abstract class CompetitionBase
    {
        public CompetitionBase()
        {
            OutcomeGroups = new();
        }

        public Guid Id { get; set; }

        public CompetitionType CompetitionType { get; set; }

        public DateTime StartTime { get; set; }

        public List<OutcomeGroup> OutcomeGroups { get; set; }
    }
}
