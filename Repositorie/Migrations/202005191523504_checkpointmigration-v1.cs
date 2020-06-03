namespace Repositorie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checkpointmigrationv1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ChecklistTypeContents", newName: "CheckPoints");
            DropColumn("dbo.CheckPoints", "ChecklistTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CheckPoints", "ChecklistTypeId", c => c.Guid(nullable: false));
            RenameTable(name: "dbo.CheckPoints", newName: "ChecklistTypeContents");
        }
    }
}
