using BetService.BusinessLogic.Models;
using BetService.BusinessLogic.Models.Competitions;

namespace BetService.BusinessLogic.Extensions
{
    public static class CoefficientGroupExtension
    {
        private static readonly double _expectedTotalProbability = 100;
        private static readonly double _systemFee = 5;

        public static CoefficientGroup RecalculateRate(this CoefficientGroup coefficientGroup)
        {
            var totalProbability = coefficientGroup.Coefficients.Sum(x => x.Probability);
            if (totalProbability != _expectedTotalProbability)
            {
                throw new ArgumentException(
                    $"Total probability do not reached. Current probability of coefficientGroup with id {coefficientGroup.Id} is {totalProbability}");
            }

            var actualProbability = _expectedTotalProbability - _systemFee;

            for (var i = 0; i < coefficientGroup.Coefficients.Count; i++)
            {
                coefficientGroup.Coefficients[i].Rate = actualProbability / coefficientGroup.Coefficients[i].Probability;
            }

            return coefficientGroup;
        }
    }
}
