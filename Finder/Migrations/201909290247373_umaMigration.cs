namespace Finder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class umaMigration : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.PreferenceValues", new[] { "Name" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.PreferenceValues", "Name");
        }
    }
}
