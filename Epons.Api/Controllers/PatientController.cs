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
            return _patientService.Get(id);
        }

        [HttpGet]
        public Patient FindByIdentificationNumber(string identificationNumber)
        {
            return _patientService.Get(identificationNumber);
        }

        [HttpGet]
        public Patient FindByDetails(string firstname, string lastname, DateTime dateOfBirth)
        {
            return _patientService.Get(firstname, lastname, dateOfBirth);
        }

        [HttpGet]
        public Pagination<Domain.EntityViews.Patient> List(Guid userId, Guid? facilityId, PatientType type, string query, int page, int size)
        {
            return _patientService.List(userId, facilityId, type, query, page, size);
        }

    }
}
