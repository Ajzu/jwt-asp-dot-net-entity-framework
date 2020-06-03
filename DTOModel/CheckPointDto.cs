using System;
using System.Collections.Generic;


namespace DTOModel
{
    public class CheckPointDto
    {
        public Guid Id { set; get; }
        public String Name { set; get; }
        public String Group { set; get; }
        public bool IsActive { set; get; }
        public DateTime CreateDate { set; get; }
        public DateTime UpdatedDate { set; get; }
    }
}
