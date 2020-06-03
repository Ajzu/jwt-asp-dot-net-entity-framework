namespace Repositorie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checklistmigrationv1 : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.ChecklistTypes",
            //    c => new
            //        {
            //            Id = c.Guid(nullable: false),
            //            Name = c.String(maxLength: 50),
            //            Description = c.String(),
            //            CreatedBy = c.Guid(),
            //            CreatedDate = c.DateTime(),
            //            UpdatedBy = c.Guid(),
            //            UpdatedDate = c.DateTime(),
            //            IsActive = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            // DropTable("dbo.ChecklistTypes");
        }
    }
}
