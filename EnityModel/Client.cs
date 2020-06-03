using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnityModel
{
    public class Client : BaseEntity
    {
        public string client_id { set; get; }
        public string client_secret { set; get; }
        public string Name { set; get; }
        public int RefreshTokenLifeTime { set; get; }
        public string AllowedOrigin { set; get; }

    }

}
