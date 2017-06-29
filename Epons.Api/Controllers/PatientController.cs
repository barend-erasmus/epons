using Epons.Domain.Entities;
using Epons.Domain.Enums;
using Epons.Domain.Models;
using Epons.Domain.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Epons.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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
        public IList<Domain.EntityViews.CompletedMeasurementTool> ListCompletedMeasurementTools(Guid patientId)
        {
            return new List<Domain.EntityViews.CompletedMeasurementTool>()
            {
                new Domain.EntityViews.CompletedMeasurementTool()
                {
                    StartDate = new DateTime(),
                    EndDate = new DateTime(),
                    MeasurementTool = new Domain.ValueObjects.MeasurementTool()
                    {

                    },
                    ScoreItems = new Dictionary<string, int>()
                    {
                        { "Eating", 1 },
                        { "Walking", 6 },
                        { "Sleeping", 7 },
                        { "Running", 5 }
                    }
                }
            };
        }

    }
}
