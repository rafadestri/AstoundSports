using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        IAthleteRepository Athlete { get; }
        ISportRepository Sport { get; }

        Task SaveAsync();
    }
}
