using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Epons.Domain.Repositories;
using Epons.Domain.Entities;

namespace Epons.Domain.Test.Repositories
{
    [TestClass]
    public class UserRepositoryTest
    {

        private readonly Guid _userId = new Guid("766B260E-DCDF-4EE5-A764-472405981E20");

        [TestMethod, TestCategory("IntegrationTest")]
        public void FindById_GivenNonExistingId_ShouldReturnNull()
        {
            UserRepository userRepository = new UserRepository();

            User patient = userRepository.FindById(new Guid());

            Assert.IsNull(patient);
        }

        [TestMethod, TestCategory("IntegrationTest")]
        public void FindById_GivenExistingId_ShouldReturnUserWithFirstname()
        {
            UserRepository userRepository = new UserRepository();

            User user = userRepository.FindById(_userId);

            Assert.IsNotNull(user.Firstname);
        }

        [TestMethod, TestCategory("IntegrationTest")]
        public void FindById_GivenExistingId_ShouldReturnUserWithLastname()
        {
            UserRepository userRepository = new UserRepository();

            User user = userRepository.FindById(_userId);

            Assert.IsNotNull(user.Lastname);
        }

        [TestMethod, TestCategory("IntegrationTest")]
        public void FindById_GivenExistingId_ShouldReturnUserWithUsername()
        {
            UserRepository userRepository = new UserRepository();

            User user = userRepository.FindById(_userId);

            Assert.IsNotNull(user.Username);
        }

        [TestMethod, TestCategory("IntegrationTest")]
        public void FindById_GivenExistingId_ShouldReturnUserWithPermissions()
        {
            UserRepository userRepository = new UserRepository();

            User user = userRepository.FindById(_userId);

            Assert.AreEqual(3, user.Permissions.Count);
        }
    }
}
