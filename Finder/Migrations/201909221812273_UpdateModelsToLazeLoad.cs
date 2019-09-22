namespace Finder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModelsToLazeLoad : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserPreferenceValues", newName: "PreferenceValueUsers");
            DropPrimaryKey("dbo.PreferenceValueUsers");
            AddPrimaryKey("dbo.PreferenceValueUsers", new[] { "PreferenceValue_Id", "User_Id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.PreferenceValueUsers");
            AddPrimaryKey("dbo.PreferenceValueUsers", new[] { "User_Id", "PreferenceValue_Id" });
            RenameTable(name: "dbo.PreferenceValueUsers", newName: "UserPreferenceValues");
        }
    }
}
