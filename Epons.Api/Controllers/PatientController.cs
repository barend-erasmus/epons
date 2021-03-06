﻿using Epons.Api.Attributes;
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
        public Domain.Entities.Patient.Patient FindById(Guid id)
        {
            HasToBeAuthenticated();

            return _patientService.Find(id);
        }

        [HttpGet]
        public Domain.Entities.Patient.Patient FindByIdentificationNumber(string identificationNumber)
        {
            HasToBeAuthenticated();

            return _patientService.Find(identificationNumber);
        }

        [HttpGet]
        public Domain.Entities.Patient.Patient FindByDetails(string firstname, string lastname, DateTime dateOfBirth)
        {
            HasToBeAuthenticated();

            return _patientService.Find(firstname, lastname, dateOfBirth);
        }

        [HttpGet]
        public int[] TimeSpent(Guid id)
        {
            HasToBeAuthenticated();

            return _patientService.TimeSpent(id);
        }

        [HttpGet]
        public bool Delete(Guid id)
        {
            HasToBeAuthenticated();

           _patientService.Delete(id);

            return true;
        }

        [HttpGet]
        public Pagination<Domain.EntityViews.Patient.Patient> List(
            Guid? userId,
            PatientType type,
            int start,
            int end,
            Guid? facilityId = null,
            string firstName = null,
            string lastName = null,
            string dateOfBirth = null,
            string gender = null,
            string race = null,
            string medicalScheme = null,
            bool superAdmin = false)
        {
            HasToBeAuthenticated();

            return _patientService.List(userId, facilityId, type, start, end, firstName, lastName, dateOfBirth, gender, race, medicalScheme, superAdmin);
        }

    }
}
