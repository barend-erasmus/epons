using Epons.Domain.EntityViews.MeasurementToolAccreditation;
using Epons.Domain.Helpers;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Epons.Domain.Repositories
{
    public class MeasurementToolAccreditationRepository
    {
        private readonly DbExecutor _dbExecutor;
        private readonly EntityFramework.EPONSContext _context;

        public MeasurementToolAccreditationRepository()
        {
            string host = ConfigurationManager.AppSettings["DatabaseHost"];
            string user = ConfigurationManager.AppSettings["DatabaseUser"];
            string name = ConfigurationManager.AppSettings["DatabaseName"];
            string password = ConfigurationManager.AppSettings["DatabasePassword"];

            string connectionString = $"data source={host};Initial Catalog={name};User ID={user};Password={Crypto.Decrypt(password)};";
            _dbExecutor = new DbExecutor(connectionString);
            _context = new EntityFramework.EPONSContext(connectionString);
        }

        public IList<MeasurementToolAccreditation> List()
        {
            return _context.MeasurementToolScores.Select((x) => new
            {
                DatePassed = x.Timestamp,
                Id = x.MeasurementToolId,
                Name = x.MeasurementTools2.Name,
                Score = x.Score,
                FullName = x.Details4.Firstname + " " + x.Details4.Lastname,
                Credentails = x.Details4.Credentials,
                UserId = x.UserId,
            }).ToList().Select((x) => new MeasurementToolAccreditation()
            {
                CountdownInDays = 0,
                DatePassed = x.DatePassed,
                FullName = x.FullName,
                Id = x.Id,
                Name = x.Name,
                Score = x.Score,
                UserId = x.UserId,
                Username = x.Credentails.First().Username,
            }).GroupBy((x) => new
            {
                UserId = x.UserId,
                Id = x.Id,
            }).Select((x) => x.OrderByDescending((y) => y.DatePassed).First()).ToList();
        }

    }
}