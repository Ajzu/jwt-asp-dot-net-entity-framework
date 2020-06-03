using System;
using System.Collections.Generic;


namespace DTOModel
{
    public class ChecklistTypeCheckPointDto
    {
        public long Id { set; get; }
        public Guid ChecklistTypeId { set; get; }
        public Guid CheckPointId { set; get; }
        public DateTime CreateDate { set; get; }
        public DateTime LastModifiedDate { set; get; }
        public bool IsActive { set; get; }
    }
}
