using Contracts;
using Entities;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;

        private IAthleteRepository _athleteRepository;
        private ISportRepository _sportRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IAthleteRepository Athlete
        {
            get
            {
                if (_athleteRepository == null)
                {
                    _athleteRepository = new AthleteRepository(_repositoryContext);
                }

                return _athleteRepository;
            }
        }

        public ISportRepository Sport
        {
            get
            {
                if (_sportRepository == null)
                {
                    _sportRepository = new SportRepository(_repositoryContext);
                }

                return _sportRepository;
            }
        }

        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    }
}
