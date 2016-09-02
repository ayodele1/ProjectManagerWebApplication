using System;
using System.Data.Entity;
using System.Linq;

namespace DataAccess
{
    public class ProjectManagerContext : DbContext
    {

        public ProjectManagerContext()
            : base("name=ProjectManagerDbConnection")
        {

        }
        public DbSet<User> Users { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<UserResponsibility> UserResponsibilites { get; set; }

        public DbSet<UserStory> UserStories { get; set; }

        public DbSet<UserStoryTask> UserStoryTasks { get; set; }

        public override int SaveChanges()
        {
            foreach (var history in this.ChangeTracker.Entries()
                .Where(e => e.Entity is IModificationHistory && (e.State == EntityState.Added || e.State == EntityState.Modified))
                .Select(e => e.Entity as IModificationHistory))
            {
                history.DateModified = DateTime.Now;
                if (history.DateCreated == DateTime.MinValue)
                    history.DateCreated = DateTime.Now;
            }
            return base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ///Shows the project each user is working on
            modelBuilder.Entity<User>()
                .HasMany(u => u.Projects)
                .WithMany(p => p.Users)
                .Map(up =>
                    {
                        up.MapLeftKey("UserId");
                        up.MapRightKey("ProjectId");
                        up.ToTable("UserProjects");
                    });

            modelBuilder.Entity<User>()
                .HasMany(u => u.ProjectsOwned)
                .WithMany(p => p.Owners)
                .Map(up =>
                {
                    up.MapLeftKey("UserId");
                    up.MapRightKey("ProjectId");
                    up.ToTable("UserProjectOwners");
                });
        }
    }
}
