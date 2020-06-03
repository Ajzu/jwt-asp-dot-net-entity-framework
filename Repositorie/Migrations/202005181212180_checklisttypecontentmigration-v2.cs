namespace Repositorie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checklisttypecontentmigrationv2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ChecklistTypeContents", "ChecklistTypeId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ChecklistTypeContents", "ChecklistTypeId", c => c.String());
        }
    }
}
