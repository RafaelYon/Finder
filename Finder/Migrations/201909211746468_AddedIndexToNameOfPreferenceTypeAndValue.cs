namespace Finder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIndexToNameOfPreferenceTypeAndValue : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PreferenceTypes", "Name", c => c.String(maxLength: 150));
            AlterColumn("dbo.PreferenceValues", "Name", c => c.String(maxLength: 150));
            CreateIndex("dbo.PreferenceTypes", "Name", unique: true);
            CreateIndex("dbo.PreferenceValues", "Name");
        }
        
        public override void Down()
        {
            DropIndex("dbo.PreferenceValues", new[] { "Name" });
            DropIndex("dbo.PreferenceTypes", new[] { "Name" });
            AlterColumn("dbo.PreferenceValues", "Name", c => c.String());
            AlterColumn("dbo.PreferenceTypes", "Name", c => c.String());
        }
    }
}
