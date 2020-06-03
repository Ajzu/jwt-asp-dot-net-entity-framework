using EnityModel;
using Repositorie.Infrastructure;
using Repositorie.Interfaces;

namespace Repositorie.Repositories
{
    public class ChapterRepository : RepositoryBase<Chapter>, IChapterRepository
    {
        public ChapterRepository() { }
    }
}
