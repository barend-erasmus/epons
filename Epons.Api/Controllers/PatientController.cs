using Epons.Domain.Entities;
using Epons.Domain.Enums;
using Epons.Domain.Models;
using Epons.Domain.Services;
using System;
using System.Web.Http;

namespace Epons.Api.Controllers
{
    public class PatientController : ApiController
    {
        private readonly PatientService _patientService;

        public PatientController(PatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public Patient FindById(Guid id)
        {
            return _patientService.Find(id);
        }

        [HttpGet]
        public Patient FindByIdentificationNumber(string identificationNumber)
        {
            return _patientService.Find(identificationNumber);
        }

        [HttpGet]
        public Patient FindByDetails(string firstname, string lastname, DateTime dateOfBirth)
        {
            return _patientService.Find(firstname, lastname, dateOfBirth);
        }

        [HttpGet]
        public Pagination<Domain.EntityViews.Patient> List(Guid userId, PatientType type, int page, int size, Guid? facilityId = null, string query = null)
        {
            return _patientService.List(userId, facilityId, type, query, page, size);
        }

    }
}
