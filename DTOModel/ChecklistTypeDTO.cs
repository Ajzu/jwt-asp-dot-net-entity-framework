using System;
using System.Collections.Generic;


namespace DTOModel
{
    public class ChecklistTypeDto
    {
        public long Id { set; get; }
        public String Name { set; get; }
        public String Description { set; get; }
        public bool IsActive { set; get; }
        public DateTime CreateDate { set; get; }
        public DateTime LastModifiedDate { set; get; }
    }
}
