using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EnityModel
{
    public class CheckPoint : BaseEntity
    {
        //[StringLength(50)]
        public String Name { set; get; }
        public String Group { set; get; }
    }
}
