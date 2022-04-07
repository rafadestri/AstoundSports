using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class SportRepository : RepositoryBase<Sport>, ISportRepository
    {
        public SportRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateSport(Sport sport)
        {
            Create(sport);
        }

        public void DeleteSport(Sport sport)
        {
            Delete(sport);
        }

        public async Task<Sport> GetSportAsync(Guid sportId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(sportId), trackChanges).SingleOrDefaultAsync();

        public async Task<IEnumerable<Sport>> GetSportsAsync(bool trackChanges) => await FindAll(trackChanges)
            .OrderBy(c => c.Name)
            .ToListAsync();

        public async Task<IEnumerable<Sport>> GetSportsByIdAsync(IEnumerable<Guid> ids, bool trackChanges) =>
            await FindByCondition(x => ids.Contains(x.Id), trackChanges).ToListAsync();
    }
}
