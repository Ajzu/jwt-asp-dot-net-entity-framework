using EnityModel;
using Repositorie.Infrastructure;
using Repositorie.Interfaces;

namespace Repositorie.Repositories
{
    public class CheckPointRepository : RepositoryBase<CheckPoint>, ICheckPointRepository
    {
        public CheckPointRepository() { }
    }
}
