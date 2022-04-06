using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IAthleteRepository
    {
        void CreateAthlete(Athlete athlete);

        void DeleteAthlete(Athlete athlete);

        Task<Athlete> GetAhtleteAsync(Guid id, bool trackChanges);

        Task<IEnumerable<Athlete>> GetAthletesAsync(bool trackChanges);
    }
}
