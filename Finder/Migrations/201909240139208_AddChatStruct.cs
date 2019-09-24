namespace Finder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddChatStruct : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserPreferenceValues", newName: "PreferenceValueUsers");
            DropPrimaryKey("dbo.PreferenceValueUsers");
            CreateTable(
                "dbo.Chats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateTable(
                "dbo.UserChats",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Chat_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Chat_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Chats", t => t.Chat_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Chat_Id);
            
            AddPrimaryKey("dbo.PreferenceValueUsers", new[] { "PreferenceValue_Id", "User_Id" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserChats", "Chat_Id", "dbo.Chats");
            DropForeignKey("dbo.UserChats", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Messages", "Chat_Id", "dbo.Chats");
            DropIndex("dbo.UserChats", new[] { "Chat_Id" });
            DropIndex("dbo.UserChats", new[] { "User_Id" });
            DropIndex("dbo.Messages", new[] { "User_Id" });
            DropIndex("dbo.Messages", new[] { "Chat_Id" });
            DropPrimaryKey("dbo.PreferenceValueUsers");
            DropTable("dbo.UserChats");
            DropTable("dbo.Messages");
            DropTable("dbo.Chats");
            AddPrimaryKey("dbo.PreferenceValueUsers", new[] { "User_Id", "PreferenceValue_Id" });
            RenameTable(name: "dbo.PreferenceValueUsers", newName: "UserPreferenceValues");
        }
    }
}
