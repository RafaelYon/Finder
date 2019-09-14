namespace Finder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedBasicDbStruct : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PreferenceTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PreferenceValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        PreferenceType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PreferenceTypes", t => t.PreferenceType_Id)
                .Index(t => t.PreferenceType_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(maxLength: 254, unicode: false),
                        Password = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email);
            
            CreateTable(
                "dbo.UserPreferenceValues",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        PreferenceValue_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.PreferenceValue_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.PreferenceValues", t => t.PreferenceValue_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.PreferenceValue_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserPreferenceValues", "PreferenceValue_Id", "dbo.PreferenceValues");
            DropForeignKey("dbo.UserPreferenceValues", "User_Id", "dbo.Users");
            DropForeignKey("dbo.PreferenceValues", "PreferenceType_Id", "dbo.PreferenceTypes");
            DropIndex("dbo.UserPreferenceValues", new[] { "PreferenceValue_Id" });
            DropIndex("dbo.UserPreferenceValues", new[] { "User_Id" });
            DropIndex("dbo.Users", new[] { "Email" });
            DropIndex("dbo.PreferenceValues", new[] { "PreferenceType_Id" });
            DropTable("dbo.UserPreferenceValues");
            DropTable("dbo.Users");
            DropTable("dbo.PreferenceValues");
            DropTable("dbo.PreferenceTypes");
        }
    }
}
