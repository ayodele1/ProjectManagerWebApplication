using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DomainObjects
{
    public class ProjectRepository
    {
        ProjectManagerContext context;
        public Project GetProjectById(int projectId)
        {
            using (context = new ProjectManagerContext())
            {
                return context.Projects.AsNoTracking().FirstOrDefault(p => p.Id == projectId);
            }
        }

        public ICollection<Project> GetAllProjects()
        {
            using (context = new ProjectManagerContext())
            {
                return context.Projects.AsNoTracking().ToList();
            }
        }

        public void AddNewProject(Project newProject, int userId)
        {
            using (context = new ProjectManagerContext())
            {
                var currentUser = context.Users.Find(userId);

                context.Projects.Add(newProject);
                currentUser.Projects.Add(newProject);
                currentUser.ProjectsOwned.Add(newProject);
                context.SaveChanges();
            }
        }

        public void DeleteProjectFromUser(int projectId, int userId)
        {
            using (context = new ProjectManagerContext())
            {
                var currentUser = context.Users.Find(userId);
                var projectToDelete = currentUser.Projects.FirstOrDefault(p => p.Id == projectId);
                context.Entry(projectToDelete).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void UpdateProjectForUser(int projectId, int userId)
        {
            using (context = new ProjectManagerContext())
            {
                var projectToUpdate = context.Projects.Find(projectId);
                context.Entry(projectToUpdate).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
