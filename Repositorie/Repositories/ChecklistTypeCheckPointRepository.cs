using EnityModel;
using Repositorie.Infrastructure;
using Repositorie.Interfaces;

namespace Repositorie.Repositories
{
    public class ChecklistTypeCheckPointRepository : RepositoryBase<ChecklistTypeCheckPoint>, IChecklistTypeCheckPointRepository
    {
        public ChecklistTypeCheckPointRepository() { }
    }
}
