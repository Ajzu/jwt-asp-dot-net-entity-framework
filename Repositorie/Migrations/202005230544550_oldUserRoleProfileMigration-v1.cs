namespace Repositorie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class oldUserRoleProfileMigrationv1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserProfiles", newName: "UserProfileOlds");
            RenameTable(name: "dbo.Users", newName: "UserOlds");
            RenameTable(name: "dbo.UserRoles", newName: "UserRolesOlds");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.UserRolesOlds", newName: "UserRoles");
            RenameTable(name: "dbo.UserOlds", newName: "Users");
            RenameTable(name: "dbo.UserProfileOlds", newName: "UserProfiles");
        }
    }
}
