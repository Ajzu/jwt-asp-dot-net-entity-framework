

namespace EnityModel
{
    public class UserRolesOld : BaseEntity
    {
        public RoleName Role { get; set; }
        public virtual UserOld User { get; set; }
    }

    public enum RoleName
    {
        SupperAdmin = 1,
        Admin = 2,
        Investor=3,
        NonInvestor=4

    }
}
