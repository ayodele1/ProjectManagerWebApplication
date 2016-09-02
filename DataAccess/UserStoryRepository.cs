using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataAccess
{
    public class UserStoryRepository
    {
        ProjectManagerContext context;
        public UserStory GetUserStoryById(int userStoryId)
        {
            using (context = new ProjectManagerContext())
            {
                var userStory = context.UserStories.AsNoTracking().FirstOrDefault(us => us.Id == userStoryId);
                return userStory;
            }
        }

        public ICollection<UserStory> GetAllUserStories()
        {
            using (context = new ProjectManagerContext())
            {
                return context.UserStories.AsNoTracking().ToList();
            }
        }

        public void AddNewUserStory(UserStory us, int projectid)
        {
            using (context = new ProjectManagerContext())
            {
                us.ProjectId = projectid;
                context.UserStories.Add(us);
                context.SaveChanges();
            }
        }

        public void DeleteUserStory(int userstoryid, int projectid)
        {
            using (context = new ProjectManagerContext())
            {
                var project = context.Projects.Find(projectid);
                var userStory = project.UserStories.FirstOrDefault(us => us.Id == userstoryid);
                context.Entry(userStory).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void UpdateUserStory(int userstoryid)
        {
            using (context = new ProjectManagerContext())
            {
                var userStory = context.UserStories.Find(userstoryid);
                context.Entry(userStory).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
