using System.Linq;

namespace DomainObjects
{
    public class UserStoryTaskRepository
    {
        private ProjectManagerContext context;

        public UserStoryTask GetUserStoryTaskById(int userStoryTaskId)
        {
            using (context = new ProjectManagerContext())
            {
                return context.UserStoryTasks.AsNoTracking().FirstOrDefault(ust => ust.Id == userStoryTaskId);
            }
        }
    }
}
