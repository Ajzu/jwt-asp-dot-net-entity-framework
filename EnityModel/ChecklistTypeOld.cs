using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace EnityModel
{
    public class ChecklistTypeOld : BaseEntity
    {
        [StringLength(50)]
        public string Name { set; get; }
        public string Description { set; get; }
    }


}
