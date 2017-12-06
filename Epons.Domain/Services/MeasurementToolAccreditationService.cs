using Epons.Domain.EntityViews.MeasurementToolAccreditation;
using Epons.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epons.Domain.Services
{
    public class MeasurementToolAccreditationService
    {
        private readonly MeasurementToolAccreditationRepository _measurementToolAccreditationRepository;
        private readonly SettingRepository _settingRepository;

        public MeasurementToolAccreditationService(MeasurementToolAccreditationRepository measurementToolAccreditationRepository, SettingRepository settingRepository)
        {
            _measurementToolAccreditationRepository = measurementToolAccreditationRepository;
            _settingRepository = settingRepository;
        }

        public IList<MeasurementToolAccreditation> List()
        {
            var result = _measurementToolAccreditationRepository.List();

            Dictionary<string, string> settings = new Dictionary<string, string>();

            foreach (var measurementToolAccreditation in result)
            {
                string setting= null;
                
                if (settings.ContainsKey($"UserMeasurementToolAccreditationExpiry-{measurementToolAccreditation.Name}"))
                {
                    setting = settings[$"UserMeasurementToolAccreditationExpiry-{measurementToolAccreditation.Name}"];
                }else
                {
                    setting = _settingRepository.Find($"UserMeasurementToolAccreditationExpiry-{measurementToolAccreditation.Name}");
                    settings.Add($"UserMeasurementToolAccreditationExpiry-{measurementToolAccreditation.Name}", setting);
                }

                if (setting == null)
                {
                    setting = "180";
                }

                measurementToolAccreditation.CountdownInDays = Convert.ToInt32(Math.Floor(measurementToolAccreditation.DatePassed.AddDays(Convert.ToInt32(setting)).Subtract(DateTime.Now).TotalDays));
            }

            return result.OrderBy((x) => x.CountdownInDays).ToList();
        }
    }
}
