namespace WebCamWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GroupMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Answer_Id = c.Int(),
                        Post_Id = c.Int(),
                        Question_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Messages", t => t.Answer_Id)
                .ForeignKey("dbo.Posts", t => t.Post_Id)
                .ForeignKey("dbo.Messages", t => t.Question_Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Msg = c.String(unicode: false),
                        Date = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Infoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Phone = c.String(unicode: false),
                        Surname = c.String(unicode: false),
                        Message = c.String(unicode: false),
                        TelegramNumber = c.String(unicode: false),
                        Instagram = c.String(unicode: false),
                        Date = c.DateTime(nullable: false, precision: 0),
                        state = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GroupMessages", "Question_Id", "dbo.Messages");
            DropForeignKey("dbo.GroupMessages", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.GroupMessages", "Answer_Id", "dbo.Messages");
            DropIndex("dbo.GroupMessages", new[] { "Question_Id" });
            DropIndex("dbo.GroupMessages", new[] { "Post_Id" });
            DropIndex("dbo.GroupMessages", new[] { "Answer_Id" });
            DropTable("dbo.Infoes");
            DropTable("dbo.Posts");
            DropTable("dbo.Messages");
            DropTable("dbo.GroupMessages");
        }
    }
}
