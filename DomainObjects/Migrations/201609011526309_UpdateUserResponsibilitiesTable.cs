namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserResponsibilitiesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserResponsibilities", "Responsibility", c => c.String(nullable: false));
            DropColumn("dbo.UserResponsibilities", "Responsiblity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserResponsibilities", "Responsiblity", c => c.String(nullable: false));
            DropColumn("dbo.UserResponsibilities", "Responsibility");
        }
    }
}
