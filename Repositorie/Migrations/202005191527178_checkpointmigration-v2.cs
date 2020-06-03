namespace Repositorie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checkpointmigrationv2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CheckPoints", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CheckPoints", "Name", c => c.String(maxLength: 50));
        }
    }
}
