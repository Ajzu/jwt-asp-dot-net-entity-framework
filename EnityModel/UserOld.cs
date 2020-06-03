using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace EnityModel
{
    public class UserOld : BaseEntity
    {
        [StringLength(50)]
        public string UserName { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Mobile { set; get; }
        public string Password { set; get; }
        public string Country { set; get; }
        public string State { set; get; }
        public string City { set; get; }
        public string ZipCode { set; get; }

        public DateTime? LastLoginTime { set; get; }

        public virtual ICollection<UserRolesOld> Roles { get; set; }

        //*May have a Profile or not*/
        //public virtual UserProfile Profile { get; set; }

}


}
