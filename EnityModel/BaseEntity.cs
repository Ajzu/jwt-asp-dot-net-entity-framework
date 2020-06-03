using System;


namespace EnityModel
{
    public abstract class BaseEntity
    {
       
        public Guid Id { get; set; }
        public Guid? CreatedBy { set; get; }
        public DateTime? CreatedDate { set; get; }
        public Guid? UpdatedBy { set; get; }
        public DateTime? UpdatedDate { set; get; }
        public bool IsActive { set; get; }
    }
}
