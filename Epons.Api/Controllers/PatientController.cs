﻿using Epons.Api.Attributes;
using Epons.Domain.Entities;
using Epons.Domain.Enums;
using Epons.Domain.Models;
using Epons.Domain.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Epons.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [JWTAuthorize]
    public class PatientController : BaseController
    {
        private readonly PatientService _patientService;

        public PatientController(PatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public Patient FindById(Guid id)
        {
            HasToBeAuthenticated();

            return _patientService.Find(id);
        }

        [HttpGet]
        public Patient FindByIdentificationNumber(string identificationNumber)
        {
            HasToBeAuthenticated();

            return _patientService.Find(identificationNumber);
        }

        [HttpGet]
        public Patient FindByDetails(string firstname, string lastname, DateTime dateOfBirth)
        {
            HasToBeAuthenticated();

            return _patientService.Find(firstname, lastname, dateOfBirth);
        }

        [HttpGet]
        public Pagination<Domain.EntityViews.Patient> List(Guid userId, PatientType type, int page, int size, Guid? facilityId = null, string query = null)
        {
            HasToBeAuthenticated();

            return _patientService.List(userId, facilityId, type, query, page, size);
        }

        [HttpGet]
        public IList<Domain.EntityViews.PatientMeasurementTool> ListMeasurementTools(Guid id, DateTime startDate, DateTime endDate)
        {
            HasToBeAuthenticated();

            return _patientService.ListMeasurementTools(id, startDate, endDate);
        }
    }
}
