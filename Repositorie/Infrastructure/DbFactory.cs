using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorie.Infrastructure
{
    public class DbFactory : IDbFactory
    {
        DataBaseContext dbContext;

        public DataBaseContext Init()
        {
            return dbContext ?? (dbContext = new DataBaseContext());
        }
    }
}
