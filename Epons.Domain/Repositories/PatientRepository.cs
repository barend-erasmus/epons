using Epons.Domain.Entities;
using Epons.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epons.Domain.Repositories
{
    public class PatientRepository
    {
        private DbExecutor _dbExecutor;

        public PatientRepository()
        {
            _dbExecutor = new DbExecutor("data source=epons.dedicated.co.za;Initial Catalog=SADFM_Dev;User ID=EPONS;Password=H@?PT@8sUeL32vBE;");
        }

        public Patient FindById(string id)
        {
            dynamic result = _dbExecutor.QueryOneProc<dynamic>("[EPONS].[FindPatientById]", new
            {
                PatientId = id
            });

            return new Patient()
            {
                Firstname = result.Firstname,
                Lastname = result.Lastname,
                DateOfBirth = result.DateOfBirth,
                IdentificationNumber = result.IdentificationNumber,
                Title = result.TitleId != null ? new Title()
                {
                    Id = result.TitleId,
                    Name = result.Title
                } : null,
                Gender = result.GenderId != null ? new Gender()
                {
                    Id = result.GenderId,
                    Name = result.Gender
                } : null
            };
        }
    }
}
