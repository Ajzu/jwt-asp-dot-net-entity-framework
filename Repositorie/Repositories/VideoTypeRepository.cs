using EnityModel;
using Repositorie.Infrastructure;
using Repositorie.Interfaces;

namespace Repositorie.Repositories
{
    public class VideoTypeRepository : RepositoryBase<VideoType>, IVideoTypeRepository
    {
        public VideoTypeRepository() { }
    }
}
