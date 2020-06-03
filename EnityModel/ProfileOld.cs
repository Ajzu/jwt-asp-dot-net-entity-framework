using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnityModel
{
    public class UserProfileOld : BaseEntity
    {
        public string Description { get; set; }
        public string Skills { get; set; }
        public string Looking { get; set; }

        public  Guid UserId { get; set; }

        /*Must have user*/
        //public virtual User user { get; set; }
    }
}
