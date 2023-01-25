using BetService.BusinessLogic.Models.Competitions;

namespace BetService.BusinessLogic.Extensions
{
    public static class CompetitionBaseExtension
    {
        /// <summary>
        /// Recalculate rate of coefficient and posability accordint with current beted amount
        /// or posability if required beted amount has been reached.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="competitionsBase"></param>
        /// <returns>Competition model inherited from <seealso cref="CompetitionBase"/> </returns>
        public static T RecalculateCoefficientsAndPosability<T>(this T competitionsBase) where T : CompetitionBase
        {
            var coefficientsGroups = competitionsBase.CoefficientGroups;
            var length = coefficientsGroups.Count;

            for (var i = 0; i < length; i++)
            {
                coefficientsGroups[i].RecalculateRate();
            }

            return competitionsBase;
        }
    }
}
