using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EnityModel
{
    public class ChecklistType : BaseEntity
    {
        [StringLength(50)]
        public String Name { set; get; }
        public String Description { set; get; }
    }
}
