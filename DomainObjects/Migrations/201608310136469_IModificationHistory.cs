namespace DomainObjects.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IModificationHistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Projects", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.UserResponsibilities", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.UserResponsibilities", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.UserStories", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.UserStories", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.UserStoryTasks", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.UserStoryTasks", "DateCreated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserStoryTasks", "DateCreated");
            DropColumn("dbo.UserStoryTasks", "DateModified");
            DropColumn("dbo.UserStories", "DateCreated");
            DropColumn("dbo.UserStories", "DateModified");
            DropColumn("dbo.UserResponsibilities", "DateCreated");
            DropColumn("dbo.UserResponsibilities", "DateModified");
            DropColumn("dbo.Users", "DateCreated");
            DropColumn("dbo.Users", "DateModified");
            DropColumn("dbo.Projects", "DateCreated");
            DropColumn("dbo.Projects", "DateModified");
        }
    }
}
