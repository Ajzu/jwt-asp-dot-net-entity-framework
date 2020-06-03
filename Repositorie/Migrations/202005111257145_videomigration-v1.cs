namespace Repositorie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class videomigrationv1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 50),
                        Description = c.String(),
                        ExternalStorageId = c.String(),
                        VideoTypeId = c.Guid(nullable: false),
                        VideoTypeAssociatedId = c.Guid(nullable: false),
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
            DropTable("dbo.Videos");
        }
    }
}
