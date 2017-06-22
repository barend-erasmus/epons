using Epons.Domain.Entities;
using Epons.Domain.Models;
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
            dynamic patientResult = _dbExecutor.QueryOneProc<dynamic>("[EPONS].[FindPatientById]", new
            {
                PatientId = id
            });

            IList<dynamic> supportServicesResult = _dbExecutor.Query<dynamic>("SELECT [patientSupportService].[SupportServiceId] AS [Id], [supportService].[Name] AS [Name], [patientSupportService].[Text] AS [Text] FROM [Patient].[SupportServices] AS [patientSupportService] INNER JOIN [ValueObjects].[SupportServices] AS [supportService] ON [patientSupportService].[PatientId] = @patientId AND [supportService].[SupportServiceId] = [patientSupportService].[SupportServiceId]", new
            {
                PatientId = id
            });

            return new Patient()
            {
                Firstname = patientResult.Firstname,
                Lastname = patientResult.Lastname,
                DateOfBirth = patientResult.DateOfBirth,
                IdentificationNumber = patientResult.IdentificationNumber,
                Title = patientResult.TitleId == null ? null : new Title()
                {
                    Id = patientResult.TitleId,
                    Name = patientResult.Title
                },
                Gender = patientResult.GenderId == null ? null : new Gender()
                {
                    Id = patientResult.GenderId,
                    Name = patientResult.Gender
                },
                Race = patientResult.RaceId == null ? null : new Race()
                {
                    Id = patientResult.RaceId,
                    Name = patientResult.Race
                },
                Address = new Models.PatientAddress()
                {
                    Street = patientResult.Street,
                    City = patientResult.CityId == null ? null : new City()
                    {
                        Id = patientResult.CityId, 
                        Name = patientResult.City
                    },
                    Country = patientResult.CountryId == null? null : new Country()
                    {
                        Id = patientResult.CountryId,
                        Name = patientResult.Country
                    },
                    PostalCode = patientResult.PostalCode,
                    Province = patientResult.ProvinceId == null? null : new Province()
                    {
                        Id = patientResult.ProvinceId,
                        Name = patientResult.Province
                    },
                    ResidentialEnvironment = patientResult.ResidentialEnvironmentId == null? null : new ResidentialEnvironment()
                    {
                        Id = patientResult.ResidentialEnvironmentId,
                        Name = patientResult.ResidentialEnvironment
                    },
                },
                ContactDetails = new PatientContactDetails()
                {
                    ContactNumber = patientResult.ContactNumber
                },
                MedicalSchemeDetails = new PatientMedicalSchemeDetails()
                {
                    MedicalScheme = patientResult.MedicalSchemeId == null? null : new MedicalScheme()
                    {
                        Id = patientResult.MedicalSchemeId,
                        Name = patientResult.MedicalScheme
                    },
                    MembershipNumber = patientResult.MedicalSchemeNumber
                },
                SupportServices = supportServicesResult.Select((x) => new PatientSupportService()
                {
                    SupportService = new SupportService()
                    {
                        Id = x.Id, 
                        Name = x.Name
                    },
                    Text = x.Text
                }).ToList()
            };
        }
    }
}
