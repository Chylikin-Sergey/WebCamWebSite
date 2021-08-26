namespace WebCamWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Messages_Changes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Type", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "Type");
        }
    }
}
