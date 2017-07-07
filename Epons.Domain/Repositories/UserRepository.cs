using Epons.Domain.Helpers;
using System;
using System.Configuration;

namespace Epons.Domain.Repositories
{
    public class UserRepository
    {
        private readonly DbExecutor _dbExecutor;

        public UserRepository()
        {
            string host = ConfigurationManager.AppSettings["DatabaseHost"];
            string user = ConfigurationManager.AppSettings["DatabaseUser"];
            string name = ConfigurationManager.AppSettings["DatabaseName"];
            string password = ConfigurationManager.AppSettings["DatabasePassword"];

            string connectionString = $"data source={host};Initial Catalog={name};User ID={user};Password={Crypto.Decrypt(password)};";
            _dbExecutor = new DbExecutor(connectionString);
        }

        public Entities.User FindById(Guid id)
        {
            dynamic userResult = _dbExecutor.QueryOneProc<dynamic>("[EPONS_API].[FindUserById]", new
            {
                UserId = id
            });

            if (userResult == null)
            {
                return null;
            }

            dynamic permissionsResult = _dbExecutor.QueryProc<dynamic>("[EPONS_API].[ListPermissionsByUserId]", new
            {
                UserId = userResult.Id
            });

            return Mapper.MapUser(userResult, permissionsResult);
        }

        public Entities.User FindByCredentials(string username, string password)
        {

            dynamic userResult = _dbExecutor.QueryOneProc<dynamic>("[EPONS_API].[FindUserIdByCredentials]", new
            {
                Username = username,
                Password = password
            });

            if (userResult == null)
            {
                return null;
            }

            return FindById(userResult.Id);
        }
    }
}
