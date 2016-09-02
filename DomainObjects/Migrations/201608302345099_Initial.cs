namespace DataAccess.Migrations
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
                        ResponsibilityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserResponsibilities", t => t.ResponsibilityId, cascadeDelete: true)
                .Index(t => t.ResponsibilityId);
            
            CreateTable(
                "dbo.UserResponsibilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Responsiblity = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserStories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(),
                        ProjectId = c.Int(nullable: false),
                        TimeEstimated = c.Double(nullable: false),
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserStories", t => t.UserStoryId, cascadeDelete: true)
                .Index(t => t.UserStoryId);
            
            CreateTable(
                "dbo.UserProjects",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Project_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Project_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.Project_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Project_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserStories", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.UserStoryTasks", "UserStoryId", "dbo.UserStories");
            DropForeignKey("dbo.Users", "ResponsibilityId", "dbo.UserResponsibilities");
            DropForeignKey("dbo.UserProjects", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.UserProjects", "User_Id", "dbo.Users");
            DropIndex("dbo.UserProjects", new[] { "Project_Id" });
            DropIndex("dbo.UserProjects", new[] { "User_Id" });
            DropIndex("dbo.UserStoryTasks", new[] { "UserStoryId" });
            DropIndex("dbo.UserStories", new[] { "ProjectId" });
            DropIndex("dbo.Users", new[] { "ResponsibilityId" });
            DropTable("dbo.UserProjects");
            DropTable("dbo.UserStoryTasks");
            DropTable("dbo.UserStories");
            DropTable("dbo.UserResponsibilities");
            DropTable("dbo.Users");
            DropTable("dbo.Projects");
        }
    }
}
