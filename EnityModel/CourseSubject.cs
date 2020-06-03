using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace EnityModel
{
    public class CourseSubject : BaseEntity
    {
        //[StringLength(50)]
        public Guid CourseId { set; get; }
        public Guid SubjectId { set; get; }
        //public int Duration { set; get; }
        //public string Thumbnail { set; get; }
        //public DateTime2 CreateDate { set; get; }
        //public DateTime LastModifiedDate { set; get; }
}


}
