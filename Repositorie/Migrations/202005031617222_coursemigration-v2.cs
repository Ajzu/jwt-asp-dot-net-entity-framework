namespace Repositorie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class coursemigrationv2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Courses", "CreateDate");
            DropColumn("dbo.Courses", "LastModifiedDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "LastModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Courses", "CreateDate", c => c.DateTime(nullable: false));
        }
    }
}
