using Epons.Domain.Entities.User;
using Epons.Domain.Helpers;
using System;
using System.Configuration;
using System.Linq;

namespace Epons.Domain.Repositories
{
    public class UserRepository
    {
        private readonly DbExecutor _dbExecutor;
        private readonly EntityFramework.EPONSContext _context;

        public UserRepository()
        {
            string host = ConfigurationManager.AppSettings["DatabaseHost"];
            string user = ConfigurationManager.AppSettings["DatabaseUser"];
            string name = ConfigurationManager.AppSettings["DatabaseName"];
            string password = ConfigurationManager.AppSettings["DatabasePassword"];

            string connectionString = $"data source={host};Initial Catalog={name};User ID={user};Password={Crypto.Decrypt(password)};";
            _dbExecutor = new DbExecutor(connectionString);
            _context = new EntityFramework.EPONSContext(connectionString);
        }

        public Entities.User.User FindById(Guid id)
        {
            var user = _context.Details4.FirstOrDefault((x) => x.UserId == id);

            if (user == null)
            {
                return null;
            }

            var position = _context.Positions.FirstOrDefault((x) => x.PositionId == user.CurrentPositionId);

            return new Entities.User.User()
            {
                ContactDetails = new ValueObjects.ContactDetails()
                {
                    ContactNumber = user.ContactNumber,
                    EmailAddress = user.EmailAddress,
                },
                Firstname = user.Firstname,
                Id = user.UserId,
                IdentificationNumber = user.IdentificationNumber,
                IsSuperAdmin = user.IsSuperAdmin,
                Lastname = user.Lastname,
                Permissions = user.Permissions.Select((x) => new
                {
                    Facility = new
                    {
                        Id = x.Detail.FacilityId,
                        Name = x.Detail.Name,
                    },
                    Permission = new
                    {
                        Id = x.Permissions1.PermissionId,
                        Name = x.Permissions1.Name,
                    }
                }).ToList().Select((x) => new UserPermission()
                {
                    Facility = new Facility()
                    {
                        Id = x.Facility.Id,
                        Name = x.Facility.Name,
                    },
                    Permission = new ValueObjects.Permission()
                    {
                        Id = x.Permission.Id,
                        Name = x.Permission.Name,
                    }
                }).ToList(),
                Position = position == null ? null : new ValueObjects.Position()
                {
                    Id = position.PositionId,
                    Name = position.Name,
                },
                ProfessionalBodyDetails = user.ProfessionalBodyId == null ? null : new Entities.User.ProfessionalBodyDetails()
                {
                    ProfessionalBody = new ValueObjects.ProfessionalBody()
                    {
                        Id = user.ProfessionalBody.ProfessionalBodyId,
                        Name = user.ProfessionalBody.Name,
                    },
                    PracticeNumber = user.PracticeNumber,
                    RegistrationNumber = user.RegistrationNumber,
                },
                Title = user.TitleId == null ? null : new ValueObjects.Title()
                {
                    Id = user.Title.TitleId,
                    Name = user.Title.Name,
                },
                Username = user.Credentials.First().Username,
                MeasurementToolAccreditations = user.MeasurementToolScores.Select((x) => new
                {
                    DatePassed = x.Timestamp,
                    Id = x.MeasurementToolId,
                    Name = x.MeasurementTools2.Name,
                    Score = x.Score,
                }).ToList().Select((x) => new MeasurementToolAccreditation()
                {
                    CountdownInDays = 0,
                    DatePassed = x.DatePassed,
                    Id = x.Id,
                    Name = x.Name,
                    Score = x.Score,
                }).ToList(),
            };
            
        }
    }
}
