namespace Repositorie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chaptermigrationv2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Chapters", "Hints", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Chapters", "Hints");
        }
    }
}
