namespace DomainObjects.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserStoryDbSet : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserStories", "UserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserStories", "UserId");
        }
    }
}
