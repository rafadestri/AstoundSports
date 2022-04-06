using Contracts;
using Entities;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;

        private ISportRepository _companyRepository;

        private IAthleteRepository _employeeRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public ISportRepository Sport
        {
            get
            {
                if (_companyRepository == null)
                {
                    _companyRepository = new SportRepository(_repositoryContext);
                }

                return _companyRepository;
            }
        }

        public IAthleteRepository Athlete
        {
            get
            {
                if (_employeeRepository == null)
                {
                    _employeeRepository = new AthleteRepository(_repositoryContext);
                }

                return _employeeRepository;
            }
        }

        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    }
}
