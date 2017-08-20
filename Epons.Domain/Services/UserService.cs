using Epons.Domain.Helpers;
using Epons.Domain.Repositories;
using System;

namespace Epons.Domain.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Entities.User.User Find(Guid id)
        {
            Entities.User.User user = _userRepository.FindById(id);

            return user;
        }
    }
}
