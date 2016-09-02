using DataAccess;
using NUnit.Framework;

namespace ProjectManager.IntegrationTests
{
    [TestFixture]
    public class UserRepositoryTests
    {
        private UserRepository _testUserRepo = new UserRepository();
        private User _testUser = new User
        {
            UserName = "ayodele",
            Email = "awoleyeayodele1@gmail.com",
            Password = "ayodele",
            Role = 'A',
            ResponsibilityId = 1
        };
        [Test]
        public void ShouldPopulateIdOnCreateUser()
        {
            _testUserRepo.AddUser(_testUser);

            Assert.That(_testUser.Id, Is.Not.EqualTo(0));
        }

        [Test]
        public void ShouldGetUserById()
        {
            var userToGet = _testUserRepo.GetUserById(0);

            Assert.That(userToGet, Is.Null);
        }

        [Test,RollBack]
        public void ShouldDeleteUser()
        {
            _testUserRepo.AddUser(_testUser);
            var userid = _testUserRepo.GetUserById(_testUser.Id).Id;
            _testUserRepo.DeleteUser(userid);
            var deletedUser = _testUserRepo.GetUserById(userid);

            Assert.That(deletedUser, Is.Null);


        }
    }
}
