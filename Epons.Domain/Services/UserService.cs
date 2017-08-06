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

        public string GetJWT(string username, string password)
        {

            string encryptedPassword = Crypto.MD5Hex(Crypto.SHA1(password));

            Entities.User.User user = _userRepository.FindByCredentials(username, encryptedPassword);

            if (user == null)
            {
                return null;
            }

            return Crypto.GenerateJWT(user.Username);
        }
    }
}
