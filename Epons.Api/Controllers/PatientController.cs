using Epons.Api.Attributes;
using Epons.Domain.Entities;
using Epons.Domain.Enums;
using Epons.Domain.Models;
using Epons.Domain.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Epons.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [JWTAuthorize]
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

        [HttpGet]
        public IList<Domain.EntityViews.CompletedMeasurementTool> ListCompletedMeasurementTools(Guid patientId, DateTime startDate, DateTime endDate)
        {
            return _patientService.ListCompletedMeasurementTools(patientId, startDate, endDate);
        }

        [HttpGet]
        public IList<Domain.EntityViews.Doctor> ListReferringDoctors(Guid patientId, Guid? facilityId = null)
        {
            return _patientService.ListReferringDoctors(patientId, facilityId);
        }
    }
}
