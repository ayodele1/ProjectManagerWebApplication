namespace DomainObjects.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        DateModified = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        confirmPassword = c.String(nullable: false),
                        ResponsibilityId = c.Int(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserResponsibilities", t => t.ResponsibilityId, cascadeDelete: true)
                .Index(t => t.ResponsibilityId);
            
            CreateTable(
                "dbo.UserResponsibilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Responsibility = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserStories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(),
                        UserId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        TimeEstimated = c.Double(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.UserStoryTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        UserStoryId = c.Int(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserStories", t => t.UserStoryId, cascadeDelete: true)
                .Index(t => t.UserStoryId);
            
            CreateTable(
                "dbo.UserProjectOwners",
                c => new
                    {
                        ProjectId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProjectId, t.UserId })
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserProjects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProjectId, t.UserId })
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserStories", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.UserStoryTasks", "UserStoryId", "dbo.UserStories");
            DropForeignKey("dbo.UserProjects", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserProjects", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.UserProjectOwners", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserProjectOwners", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Users", "ResponsibilityId", "dbo.UserResponsibilities");
            DropIndex("dbo.UserProjects", new[] { "UserId" });
            DropIndex("dbo.UserProjects", new[] { "ProjectId" });
            DropIndex("dbo.UserProjectOwners", new[] { "UserId" });
            DropIndex("dbo.UserProjectOwners", new[] { "ProjectId" });
            DropIndex("dbo.UserStoryTasks", new[] { "UserStoryId" });
            DropIndex("dbo.UserStories", new[] { "ProjectId" });
            DropIndex("dbo.Users", new[] { "ResponsibilityId" });
            DropTable("dbo.UserProjects");
            DropTable("dbo.UserProjectOwners");
            DropTable("dbo.UserStoryTasks");
            DropTable("dbo.UserStories");
            DropTable("dbo.UserResponsibilities");
            DropTable("dbo.Users");
            DropTable("dbo.Projects");
        }
    }
}
