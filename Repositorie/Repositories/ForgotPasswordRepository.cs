using EnityModel;
using Repositorie.Infrastructure;
using Repositorie.Interfaces;

namespace Repositorie.Repositories
{
    public class ForgotPasswordRepository : RepositoryBase<ForgotPassword>, IForgotPasswordRepository
    {
        public ForgotPasswordRepository() { }
    }
}
