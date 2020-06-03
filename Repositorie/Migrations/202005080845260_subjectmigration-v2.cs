namespace Repositorie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class subjectmigrationv2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Subjects", "Progress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Subjects", "Progress", c => c.Int(nullable: false));
        }
    }
}
