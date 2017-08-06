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

        public Entities.User.User FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Entities.User.User FindByCredentials(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
