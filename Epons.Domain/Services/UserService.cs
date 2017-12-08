using Epons.Domain.Helpers;
using Epons.Domain.Repositories;
using System;
using System.Linq;

namespace Epons.Domain.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly SettingRepository _settingRepository;

        public UserService(UserRepository userRepository, SettingRepository settingRepository)
        {
            _userRepository = userRepository;
            _settingRepository = settingRepository;
        }

        public Entities.User.User Find(Guid id)
        {
            Entities.User.User user = _userRepository.FindById(id);

            if (user == null)
            {
                return null;
            }

            foreach (var measurementToolAccreditation in user.MeasurementToolAccreditations)
            {
                var setting = _settingRepository.Find($"UserMeasurementToolAccreditationExpiry-{measurementToolAccreditation.Name}");

                if (setting == null)
                {
                    setting = "180";
                }

                measurementToolAccreditation.ExpiryDate = measurementToolAccreditation.DatePassed.AddDays(Convert.ToInt32(setting));
                measurementToolAccreditation.CountdownInDays = Convert.ToInt32(Math.Floor(measurementToolAccreditation.DatePassed.AddDays(Convert.ToInt32(setting)).Subtract(DateTime.Now).TotalDays));
            }

            user.MeasurementToolAccreditations = user.MeasurementToolAccreditations.OrderBy((x) => x.DatePassed).ToList();

            return user;
        }
    }
}
