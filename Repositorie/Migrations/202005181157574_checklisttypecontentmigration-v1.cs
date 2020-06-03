namespace Repositorie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checklisttypecontentmigrationv1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChecklistTypeContents",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 50),
                        Group = c.String(),
                        ChecklistTypeId = c.String(),
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
            DropTable("dbo.ChecklistTypeContents");
        }
    }
}
