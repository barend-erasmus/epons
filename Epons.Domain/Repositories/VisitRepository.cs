using Epons.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Epons.Domain.Repositories
{
    public class VisitRepository
    {
        private readonly DbExecutor _dbExecutor;
        private readonly EntityFramework.EPONSContext _context;

        public VisitRepository()
        {
            string host = ConfigurationManager.AppSettings["DatabaseHost"];
            string user = ConfigurationManager.AppSettings["DatabaseUser"];
            string name = ConfigurationManager.AppSettings["DatabaseName"];
            string password = ConfigurationManager.AppSettings["DatabasePassword"];

            string connectionString = $"data source={host};Initial Catalog={name};User ID={user};Password={Crypto.Decrypt(password)};";
            _dbExecutor = new DbExecutor(connectionString);

            _context = new EntityFramework.EPONSContext(connectionString);
        }

        public IList<EntityViews.Visit.Visit> List(Guid patientId, DateTime startDate, DateTime endDate)
        {
            return _context.Details5
                .Where((x) => x.PatientId == patientId && x.Timestamp >= startDate && x.Timestamp <= endDate)
                .Select((x) => new
            {
                Id = x.VisitId,
                DailyNotes = x.DailyNotes,
                ProgressNotes = x.ProgressNotes,
                Duration = x.DurationofVisitinMinutes,
                Timestamp = x.Timestamp,
                User = new
                {
                    Id = x.Details4.UserId,
                    Firstname = x.Details4.Firstname,
                    Lastname = x.Details4.Lastname,
                    Permissions = x.Details4.Permissions.Select((y) => new
                    {
                       Permission = new
                       {
                           Id = y.PermissionId,
                           Name = y.Permissions1.Name
                       },
                        Facility = new
                        {
                            Id = y.FacilityId,
                            Name = y.Detail.Name
                        }
                    })
                },
                MeasurementTools = x.ScoreValues.Select((y) => new
                {
                    Id = y.ScoreItem.MeasurementTools2.MeasurementToolId,
                    Name = y.ScoreItem.MeasurementTools2.Name
                }),
                VitalSigns = new
                {
                    Temperature = x.Temperature,
                    HeartRate = x.HeartRate,
                    BloodPressureSystolic = x.BloodPressureSystolic,
                    BloodPressureDiastolic = x.BloodPressureDiastolic,
                    RespiratoryRate = x.RespiratoryRate,
                    PulseOximetry = x.PulseOximetry,
                    Glucose = x.Glucose
                }
            })
            .ToList().Select((x) => new EntityViews.Visit.Visit()
            {
                Id = x.Id,
                DailyNotes = x.DailyNotes,
                ProgressNotes = x.ProgressNotes,
                Duration = x.Duration.HasValue? x.Duration.Value : 0,
                Timestamp = x.Timestamp,
                User = new EntityViews.Visit.User()
                {
                    Fullname = $"{x.User.Firstname} {x.User.Lastname}",
                    Id = x.User.Id,
                    Permissions = x.User.Permissions.Select((y) => new EntityViews.Visit.UserPermission()
                    {
                        Facility = new EntityViews.Visit.Facility()
                        {
                            Id = y.Facility.Id,
                            Name = y.Facility.Name
                        },
                        Permission = new ValueObjects.Permission()
                        {
                            Id = y.Permission.Id,
                            Name = y.Permission.Name
                        }
                    }).ToList()
                },
                MeasurementTools = x.MeasurementTools.Select((y) => new ValueObjects.MeasurementTool()
                {
                    Id = y.Id,
                    Name = y.Name
                }).ToList(),
                VitalSigns = new ValueObjects.VitalSigns()
                {
                    Temperature = ZeroToNull(x.VitalSigns.Temperature),
                    BloodPressureDiastolic = ZeroToNull(x.VitalSigns.BloodPressureDiastolic),
                    BloodPressureSystolic = ZeroToNull(x.VitalSigns.BloodPressureSystolic),
                    Glucose = ZeroToNull(x.VitalSigns.Glucose),
                    HeartRate = ZeroToNull(x.VitalSigns.HeartRate),
                    PulseOximetry = ZeroToNull(x.VitalSigns.PulseOximetry),
                    RespiratoryRate = ZeroToNull(x.VitalSigns.RespiratoryRate)
                }
            }).ToList();
        }

        public IList<EntityViews.CompletedMeasurementTool.CompletedMeasurementTool> ListCompletedMeasurementTools(Guid patientId, DateTime startDate, DateTime endDate)
        {
            var result = _dbExecutor.QueryProc<dynamic>("[EPONS_API].[FindCompletedMeasurementToolsByPatientIdAndDateRange]", new
            {
                patientId = patientId,
                startDate = startDate,
                endDate = endDate
            });

            return result
                .GroupBy(x => x.DataSetId)
                .Select(x => new EntityViews.CompletedMeasurementTool.CompletedMeasurementTool()
                {
                    EndDate = x.First().EndDate,
                    StartDate = x.First().StartDate,
                    MeasurementTool = new ValueObjects.MeasurementTool()
                    {
                        Id = x.First().MeasurementToolId,
                        Name = x.First().MeasurementTool,
                    },
                    ScoreItems = x.OrderBy(y => y.ScoreItemSortOrder).ToDictionary(y => (string)y.ScoreItem, y => (int)y.ScoreValue)
                }).ToList();
        }

        private int? ZeroToNull(int? value)
        {
            if (value.HasValue)
            {
                if (value == 0)
                {
                    return null;
                }
            }

            return value;
        }

        private double? ZeroToNull(double? value)
        {
            if (value.HasValue)
            {
                if (value == 0)
                {
                    return null;
                }
            }

            return value;
        }
    }
}
