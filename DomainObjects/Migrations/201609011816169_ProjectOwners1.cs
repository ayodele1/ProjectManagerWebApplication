namespace DomainObjects.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjectOwners1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.UserProjectOwners");
            DropPrimaryKey("dbo.UserProjects");
            AddPrimaryKey("dbo.UserProjectOwners", new[] { "ProjectId", "UserId" });
            AddPrimaryKey("dbo.UserProjects", new[] { "ProjectId", "UserId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UserProjects");
            DropPrimaryKey("dbo.UserProjectOwners");
            AddPrimaryKey("dbo.UserProjects", new[] { "UserId", "ProjectId" });
            AddPrimaryKey("dbo.UserProjectOwners", new[] { "UserId", "ProjectId" });
        }
    }
}
