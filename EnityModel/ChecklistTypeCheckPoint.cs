using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EnityModel
{
    public class ChecklistTypeCheckPoint : BaseEntity
    {
        //[StringLength(50)]
        public Guid ChecklistTypeId { set; get; }
        public Guid CheckPointId { set; get; }
    }
}
