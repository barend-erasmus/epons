
using Epons.Domain.Helpers;
using System;
using System.Configuration;
using System.Linq;

namespace Epons.Domain.Repositories
{
    public class FacilityRepository
    {
        private readonly EntityFramework.EPONSContext _context;

        public FacilityRepository()
        {
            string host = ConfigurationManager.AppSettings["DatabaseHost"];
            string user = ConfigurationManager.AppSettings["DatabaseUser"];
            string name = ConfigurationManager.AppSettings["DatabaseName"];
            string password = ConfigurationManager.AppSettings["DatabasePassword"];

            string connectionString = $"data source={host};Initial Catalog={name};User ID={user};Password={Crypto.Decrypt(password)};MultipleActiveResultSets=true;";
            _context = new EntityFramework.EPONSContext(connectionString);
        }

        public int CalculateTimeSpent(Guid id, int overLastHours)
        {
            DateTime timestamp = DateTime.Now.Subtract(new TimeSpan(overLastHours, 0, 0));

            return _context.Details5.Where((x) => x.Details4.Permissions.Count((y) => y.FacilityId == id) > 0 & x.Timestamp >= timestamp)
                .ToList()
                .Sum((y) => y.DurationofVisitinMinutes).Value;
        }

        public EntityViews.Facility.Facility FindById(Guid id)
        {
            var result = _context.Details.FirstOrDefault((x) => x.FacilityId == id);

            if (result == null)
            {
                return null;
            }

            return new EntityViews.Facility.Facility()
            {
                Id = id,
                Avatar = result.Avatar,
                Name = result.Name,
                Locked = _context.Details4.Count((x) => x.Credentials.FirstOrDefault().Locked && x.Permissions.Count((y) => y.FacilityId == id) > 0) == _context.Details4.Count((x) => x.Permissions.Count((y) => y.FacilityId == id) > 0)
            };
        }

        public void Lock(Guid id)
        {
            var userIds = _context.Credentials.Where((x) => x.Details4.Permissions.Count((y) => y.FacilityId == id) > 0).Select((x) => x.UserId).ToList();

            foreach (var userId in userIds)
            {
                var credentails = _context.Database.ExecuteSqlCommand("UPDATE [User].[Credentials] SET [Locked] = {0} WHERE [UserId] = {1}", true, userId);
            }

            _context.SaveChanges();
        }

        public void Unlock(Guid id)
        {
            var userIds = _context.Credentials.Where((x) => x.Details4.Permissions.Count((y) => y.FacilityId == id) > 0).Select((x) => x.UserId).ToList();

            foreach (var userId in userIds)
            {
                var credentails = _context.Database.ExecuteSqlCommand("UPDATE [User].[Credentials] SET [Locked] = {0} WHERE [UserId] = {1}", false, userId);
            }

            _context.SaveChanges();
        }
    }
}
