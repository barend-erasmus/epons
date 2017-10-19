using Epons.Domain.Helpers;
using System.Configuration;

namespace Epons.Domain.Repositories
{
    public class SettingRepository
    {

        private readonly DbExecutor _dbExecutor;

        public SettingRepository()
        {
            string host = ConfigurationManager.AppSettings["DatabaseHost"];
            string user = ConfigurationManager.AppSettings["DatabaseUser"];
            string name = ConfigurationManager.AppSettings["DatabaseName"];
            string password = ConfigurationManager.AppSettings["DatabasePassword"];

            string connectionString = $"data source={host};Initial Catalog={name};User ID={user};Password={Crypto.Decrypt(password)};";
            _dbExecutor = new DbExecutor(connectionString);
        }

        public string Find(string name)
        {
            return _dbExecutor.QueryOne<dynamic>("[EPONS_API].[FindSetting]", new
            {
                name = name,
            });
        }

        public void Update(string name, string value)
        {
            
        }
    }
}
