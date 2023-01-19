using System.Runtime.CompilerServices;
using BetService.BusinessLogic.Enums;

namespace BetService.BusinessLogic.Models
{
    public class Coefficient
    {
        public Guid Id { get; set; }

        public double Rate { get; set; }

        public CoefficientStatusType StatusType { get; set; }

        public double Amount { get; set; }

        public double Probability { get; set; }
    }
}
