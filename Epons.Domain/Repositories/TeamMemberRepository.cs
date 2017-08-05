using Epons.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Epons.Domain.Repositories
{
    public class TeamMemberRepository
    {
        private readonly DbExecutor _dbExecutor;
        private readonly EntityFramework.EPONSContext _context;

        public TeamMemberRepository()
        {
            string host = ConfigurationManager.AppSettings["DatabaseHost"];
            string user = ConfigurationManager.AppSettings["DatabaseUser"];
            string name = ConfigurationManager.AppSettings["DatabaseName"];
            string password = ConfigurationManager.AppSettings["DatabasePassword"];

            string connectionString = $"data source={host};Initial Catalog={name};User ID={user};Password={Crypto.Decrypt(password)};";
            _dbExecutor = new DbExecutor(connectionString);
            _context = new EntityFramework.EPONSContext(connectionString);
        }

        public IList<EntityViews.TeamMember> List(Guid patientId, DateTime startDate, DateTime endDate)
        {
            return _context.TeamMembers.Where(x => x.PatientId == patientId).Select(x => new
            {
                AllocationTimestamp = x.AllocationTimestamp,
                DeallocationTimestamp = x.DeallocationTimestamp,
                Facility = new
                {
                    Id = x.FacilityId,
                    Name = x.Detail.Name
                },
                User = new
                {
                    Id = x.Details4.UserId,
                    Firstname = x.Details4.Firstname,
                    Lastname = x.Details4.Lastname,
                    Permissions = x.Details4.Permissions.Select(y => new {
                        Facility = new
                        {
                            Id = y.FacilityId,
                            Name = y.Detail.Name
                        },
                        Permission = new
                        {
                            Id = y.PermissionId,
                            Name = y.Permissions1.Name
                        }
                    }),
                    Position = x.Details4.CurrentPositionId.HasValue ? new
                    {
                        Id = x.Details4.CurrentPositionId.Value,
                        Name = _context.Positions.SingleOrDefault(y => y.PositionId == x.Details4.CurrentPositionId).Name
                    } : null
                }
            }).ToList()
            .Select(x => new EntityViews.TeamMember()
            {
                AllocationTimestamp = x.AllocationTimestamp,
                DeallocationTimestamp = x.DeallocationTimestamp,
                Facility = new ValueObjects.Facility()
                {
                    Id = x.Facility.Id,
                    Name = x.Facility.Name
                },
                User = new Models.TeamMemberUser()
                {
                    Id = x.User.Id,
                    Fullname = $"{x.User.Firstname} {x.User.Lastname}",
                    Permissions = x.User.Permissions.Select(y => new Models.UserPermission()
                    {
                        Facility = new ValueObjects.Facility()
                        {
                            Id = y.Facility.Id,
                            Name = y.Facility.Name
                        },
                        Permission = new ValueObjects.Permission()
                        {
                            Id = y.Permission.Id,
                            Name = y.Permission.Name
                        }
                    }).ToList(),
                    Position = x.User.Position == null ? new ValueObjects.Position()
                    {
                        Id = x.User.Position.Id,
                        Name = x.User.Position.Name
                    } : null
                }
            }).ToList();
        }
    }
}
