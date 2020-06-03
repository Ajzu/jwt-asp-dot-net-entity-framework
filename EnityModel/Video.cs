using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace EnityModel
{
    public class Video : BaseEntity
    {
        [StringLength(50)]
        public string Name { set; get; }
        public string Description { set; get; }
        public string ExternalStorageId { set; get; }
        public Guid VideoTypeId { set; get; }
        public Guid VideoTypeAssociatedId { set; get; }
    }


}
