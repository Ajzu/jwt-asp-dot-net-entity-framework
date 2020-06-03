using System;
using System.Collections.Generic;


namespace DTOModel
{
    public class VideoDto
    {
        public long Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string ExternalStorageId { set; get; }
        public string VideoTypeName { set; get; }
        public Guid VideoTypeId { set; get; }
        public Guid VideoTypeAssociatedId { set; get; }
        public bool IsActive { set; get; }
        public DateTime CreateDate { set; get; }
        public DateTime LastModifiedDate { set; get; }        
    }
}
