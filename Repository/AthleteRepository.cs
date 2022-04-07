using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class AthleteRepository : RepositoryBase<Athlete>, IAthleteRepository
    {
        public AthleteRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateAthlete(Athlete athlete) => Create(athlete);

        public void DeleteAthlete(Athlete athlete) => Delete(athlete);

        public async Task<Athlete> GetAthleteAsync(Guid id, bool trackChanges) => await FindByCondition(a => a.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<Athlete>> GetAthletesAsync(bool trackChanges) => await FindAll(trackChanges).OrderBy(a => a.Name).ToListAsync();
    }
}
