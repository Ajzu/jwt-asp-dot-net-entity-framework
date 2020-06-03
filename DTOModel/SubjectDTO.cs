using System;
using System.Collections.Generic;


namespace DTOModel
{
    public class SubjectDto
    {
        public long Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public int Duration { set; get; }
        public string Thumbnail { set; get; }
        public DateTime CreateDate { set; get; }
        public DateTime LastModifiedDate { set; get; }
        //public int Progress { set; get; }
        //public string Mobile { set; get; }
        //public string Country { set; get; }
        //public string State { set; get; }
        //public string City { set; get; }
        //public DateTime? LastLoginTime { set; get; }
        //public string ZipCode { set; get; }

        //public List<UserRoleDto> UserRoles { set; get; }
    }
}
