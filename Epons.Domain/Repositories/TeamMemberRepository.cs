using Epons.Domain.Entities;
using Epons.Domain.Helpers;
using Epons.Domain.Models;
using Epons.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using static Dapper.SqlMapper;

namespace Epons.Domain.Repositories
{
    public class TeamMemberRepository
    {
        private DbExecutor _dbExecutor;

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
