namespace Finder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUniqueConstraintToEmailOfUsersTable : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Users", "Email", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "Email" });
        }
    }
}
