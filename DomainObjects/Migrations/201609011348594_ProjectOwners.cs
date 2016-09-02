namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjectOwners : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.UserProjects", name: "User_Id", newName: "UserId");
            RenameColumn(table: "dbo.UserProjects", name: "Project_Id", newName: "ProjectId");
            RenameIndex(table: "dbo.UserProjects", name: "IX_User_Id", newName: "IX_UserId");
            RenameIndex(table: "dbo.UserProjects", name: "IX_Project_Id", newName: "IX_ProjectId");
            CreateTable(
                "dbo.UserProjectOwners",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.ProjectId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ProjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProjectOwners", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.UserProjectOwners", "UserId", "dbo.Users");
            DropIndex("dbo.UserProjectOwners", new[] { "ProjectId" });
            DropIndex("dbo.UserProjectOwners", new[] { "UserId" });
            DropTable("dbo.UserProjectOwners");
            RenameIndex(table: "dbo.UserProjects", name: "IX_ProjectId", newName: "IX_Project_Id");
            RenameIndex(table: "dbo.UserProjects", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.UserProjects", name: "ProjectId", newName: "Project_Id");
            RenameColumn(table: "dbo.UserProjects", name: "UserId", newName: "User_Id");
        }
    }
}
