namespace DomainObjects.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserResponsibilities", "DateModified");
            DropColumn("dbo.UserResponsibilities", "DateCreated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserResponsibilities", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.UserResponsibilities", "DateModified", c => c.DateTime(nullable: false));
        }
    }
}
