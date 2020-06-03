namespace Repositorie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class forgotpasswordmigrationv1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ForgotPasswords",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Email = c.String(),
                        OTP = c.String(),
                        CreatedBy = c.Guid(),
                        CreatedDate = c.DateTime(),
                        UpdatedBy = c.Guid(),
                        UpdatedDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ForgotPasswords");
        }
    }
}
