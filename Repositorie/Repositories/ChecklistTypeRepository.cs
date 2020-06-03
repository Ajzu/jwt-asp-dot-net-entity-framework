using EnityModel;
using Repositorie.Infrastructure;
using Repositorie.Interfaces;

namespace Repositorie.Repositories
{
    public class ChecklistTypeRepository : RepositoryBase<ChecklistType>, IChecklistTypeRepository
    {
        public ChecklistTypeRepository() { }
    }
}
