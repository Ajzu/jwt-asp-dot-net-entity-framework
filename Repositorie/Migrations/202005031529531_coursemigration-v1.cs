namespace Repositorie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class coursemigrationv1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Name", c => c.String(maxLength: 50));
            AddColumn("dbo.Courses", "Description", c => c.String());
            AddColumn("dbo.Courses", "Duration", c => c.Int(nullable: false));
            AddColumn("dbo.Courses", "Thumbnail", c => c.String());
            AddColumn("dbo.Courses", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Courses", "LastModifiedDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Courses", "CourseName");
            DropColumn("dbo.Courses", "FirstName");
            DropColumn("dbo.Courses", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "LastName", c => c.String());
            AddColumn("dbo.Courses", "FirstName", c => c.String());
            AddColumn("dbo.Courses", "CourseName", c => c.String(maxLength: 50));
            DropColumn("dbo.Courses", "LastModifiedDate");
            DropColumn("dbo.Courses", "CreateDate");
            DropColumn("dbo.Courses", "Thumbnail");
            DropColumn("dbo.Courses", "Duration");
            DropColumn("dbo.Courses", "Description");
            DropColumn("dbo.Courses", "Name");
        }
    }
}
