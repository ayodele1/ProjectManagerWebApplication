namespace DomainObjects.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "confirmPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "confirmPassword", c => c.String(nullable: false));
        }
    }
}
