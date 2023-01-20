using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BetService.BusinessLogic.Models.Competitions;

namespace BetService.BusinessLogic.Contracts.Repositories
{
    public interface ICompetitionRepository<T> where T : class
    {
        Task CreateCompetition(T item, CancellationToken cancellationToken);

        Task DeleteCompetitionById(Guid Id, CancellationToken cancellationToken);

        Task UpdateCompetition(T item, CancellationToken cancellationToken);
    }
}
