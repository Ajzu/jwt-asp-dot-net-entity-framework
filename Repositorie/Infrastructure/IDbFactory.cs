using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorie.Infrastructure
{
    public interface IDbFactory
    {
        DataBaseContext Init();
    }
}
