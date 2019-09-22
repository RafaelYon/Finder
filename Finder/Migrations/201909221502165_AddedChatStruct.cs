namespace Finder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedChatStruct : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        FirstUser_Id = c.Int(),
                        SecondUser_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.FirstUser_Id)
                .ForeignKey("dbo.Users", t => t.SecondUser_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.FirstUser_Id)
                .Index(t => t.SecondUser_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        Chat_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chats", t => t.Chat_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Chat_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Chats", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Chats", "SecondUser_Id", "dbo.Users");
            DropForeignKey("dbo.Messages", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Messages", "Chat_Id", "dbo.Chats");
            DropForeignKey("dbo.Chats", "FirstUser_Id", "dbo.Users");
            DropIndex("dbo.Messages", new[] { "User_Id" });
            DropIndex("dbo.Messages", new[] { "Chat_Id" });
            DropIndex("dbo.Chats", new[] { "User_Id" });
            DropIndex("dbo.Chats", new[] { "SecondUser_Id" });
            DropIndex("dbo.Chats", new[] { "FirstUser_Id" });
            DropTable("dbo.Messages");
            DropTable("dbo.Chats");
        }
    }
}
