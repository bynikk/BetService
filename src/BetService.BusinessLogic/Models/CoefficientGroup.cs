using BetService.BusinessLogic.Enums;

namespace BetService.BusinessLogic.Models
{
    public class CoefficientGroup
    {
        public CoefficientGroup()
        {
            Coefficients = new();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public CoefficientGroupType Type { get; set; }

        public List<Coefficient> Coefficients { get; set; }
    }
}
