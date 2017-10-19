using Epons.Domain.Enums;
using Epons.Domain.Repositories;
using Epons.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Epons.Domain.Services
{
    public class SettingService
    {
        private readonly SettingRepository _settingRepository;

        public SettingService(SettingRepository settingRepository)
        {
            _settingRepository = settingRepository;
        }

        public string Find(string name)
        {
            return _settingRepository.Find(name);
        }

        public void Update(string name, string value)
        {
            _settingRepository.Update(name, value);
        }
    }
}
