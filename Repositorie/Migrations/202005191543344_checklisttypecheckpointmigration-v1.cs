namespace Repositorie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checklisttypecheckpointmigrationv1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChecklistTypeCheckPoints",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ChecklistTypeId = c.Guid(nullable: false),
                        CheckPointId = c.Guid(nullable: false),
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
            DropTable("dbo.ChecklistTypeCheckPoints");
        }
    }
}
