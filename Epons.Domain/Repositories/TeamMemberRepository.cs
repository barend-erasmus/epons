using Epons.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Epons.Domain.Repositories
{
    public class TeamMemberRepository
    {
        private readonly DbExecutor _dbExecutor;

        public TeamMemberRepository()
        {
            string host = ConfigurationManager.AppSettings["DatabaseHost"];
            string user = ConfigurationManager.AppSettings["DatabaseUser"];
            string name = ConfigurationManager.AppSettings["DatabaseName"];
            string password = ConfigurationManager.AppSettings["DatabasePassword"];

            string connectionString = $"data source={host};Initial Catalog={name};User ID={user};Password={Crypto.Decrypt(password)};";
            _dbExecutor = new DbExecutor(connectionString);
        }

        public IList<EntityViews.TeamMember> List(Guid patientId)
        {
            return null;
        }
    }
}
