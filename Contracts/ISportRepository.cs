using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ISportRepository
    {
        void CreateSport(Sport sport);

        void DeleteSport(Sport sport);

        Task<Sport> GetSportAsync(Guid sportId, bool trackChanges);

        Task<IEnumerable<Sport>> GetSportsAsync(bool trackChanges);

        Task<IEnumerable<Sport>> GetSportsByIdAsync(IEnumerable<Guid> ids, bool trackChanges);
    }
}
