using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EnityModel
{
    public class User : BaseEntity
    {
        //[StringLength(50)]
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
}
}
