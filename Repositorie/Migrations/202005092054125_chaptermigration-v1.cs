namespace Repositorie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chaptermigrationv1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chapters",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 50),
                        Description = c.String(),
                        Duration = c.Int(nullable: false),
                        Thumbnail = c.String(),
                        Content = c.String(),
                        CreatedBy = c.Guid(),
                        CreatedDate = c.DateTime(),
                        UpdatedBy = c.Guid(),
                        UpdatedDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubjectChapters",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SubjectId = c.Guid(nullable: false),
                        ChapterId = c.Guid(nullable: false),
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
            DropTable("dbo.SubjectChapters");
            DropTable("dbo.Chapters");
        }
    }
}
