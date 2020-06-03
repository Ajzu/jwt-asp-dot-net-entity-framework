using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOModel
{
   public class ProfileOldDTO
    {
        public long Id { set; get; }
        public string Description { get; set; }
        public string[] Skills { get; set; }
        public string Looking { get; set; }

        public Guid UserId { get; set; }
    }
}
