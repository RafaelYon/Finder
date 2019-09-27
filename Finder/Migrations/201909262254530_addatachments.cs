namespace Finder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addatachments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Born", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "Genre", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Genre");
            DropColumn("dbo.Users", "Born");
        }
    }
}
