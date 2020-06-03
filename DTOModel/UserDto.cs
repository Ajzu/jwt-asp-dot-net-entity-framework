using System;
using System.Collections.Generic;


namespace DTOModel
{
    public class UserDto
    {
        public Guid Id { set; get; }
        public String Name { set; get; }
        public String Email { set; get; }
        public String Password { set; get; }
        public String FirstName { set; get; }
        public String LastName { set; get; }
        public String Mobile { set; get; }
        public Guid Country { set; get; }
        public Guid State { set; get; }
        public String City { set; get; }
        public int ZipCode { set; get; }
        public bool IsActive { set; get; }
        public DateTime CreateDate { set; get; }
        public DateTime LastModifiedDate { set; get; }
    }
}
