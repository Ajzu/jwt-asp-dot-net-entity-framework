using System;
using System.Collections.Generic;


namespace DTOModel
{
    public class UserOldDto
    {
        public long Id { set; get; }
        public string UserName { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Mobile { set; get; }
        public string Country { set; get; }
        public string State { set; get; }
        public string City { set; get; }
        public DateTime? LastLoginTime { set; get; }
        public string ZipCode { set; get; }

        public List<UserRoleOldDto> UserRoles { set; get; }
    }
}
