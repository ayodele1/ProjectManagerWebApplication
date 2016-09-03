
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
namespace DomainObjects
{
    public class UserRepository
    {
        public User GetUserById(int userId)
        {
            using (var context = new ProjectManagerContext())
            {
                var user = context.Users.Include(p => p.ProjectsOwned).Include(p => p.Projects).FirstOrDefault(u => u.Id == userId);
                return user;
            }
        }

        public ICollection<User> GetAllUsers()
        {
            using (var context = new ProjectManagerContext())
            {
                var users = context.Users.AsNoTracking().ToList();
                return users;
            }
        }

        public void AddUser(User newUser)
        {
            using (var context = new ProjectManagerContext())
            {
                context.Users.Add(newUser);
                context.SaveChanges();
            }
        }

        public void DeleteUser(int userId)
        {
            using (var context = new ProjectManagerContext())
            {
                var userToDelete = context.Users.Find(userId);
                context.Entry(userToDelete).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void UpdateUser(User userToUpdate)
        {
            using (var context = new ProjectManagerContext())
            {
                context.Entry(userToUpdate).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
