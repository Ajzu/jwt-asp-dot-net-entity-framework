using System;
using System.Collections.Generic;


namespace DTOModel
{
    public class ChecklistTypeDtoOld
    {
        public long Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public bool IsActive { set; get; }
        public DateTime CreateDate { set; get; }
        public DateTime LastModifiedDate { set; get; }        
    }
}
