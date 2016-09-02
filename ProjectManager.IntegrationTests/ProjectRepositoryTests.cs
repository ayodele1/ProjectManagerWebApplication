using DataAccess;
using NUnit.Framework;

namespace ProjectManager.IntegrationTests
{
    [TestFixture]
    public class ProjectRepositoryTests
    {
        private ProjectRepository _projectRepo = new ProjectRepository();
        private UserRepository _userRepo = new UserRepository();
        private Project _testProject = new Project
        {
            Name = "DummyAndroid",
            Description = "This ia a dummy android application",
        };
        [Test, RollBack]
        public void ShouldbeAddedToUser()
        {
            var user = _userRepo.GetUserById(9);
            if (user != null)
            {
                _projectRepo.AddNewProject(_testProject, user.Id);
                
            }
            user = _userRepo.GetUserById(9);
            var p = _projectRepo.GetProjectById(_testProject.Id);
            Assert.That(p.Owners.Count, Is.GreaterThan(0));
            Assert.That(user.ProjectsOwned.Count, Is.GreaterThan(0));
        }
    }
}
