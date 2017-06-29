using Epons.Domain.Entities;
using Epons.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public Patient Find(Guid id)
        {
            return _patientService.Get(id);
        }

        [HttpGet]
        public Patient Find(string identificationNumber)
        {
            return _patientService.Get(identificationNumber);
        }

        [HttpGet]
        public Patient Find(string firstname, string lastname, DateTime dateOfBirth)
        {
            return _patientService.Get(firstname, lastname, dateOfBirth);
        }

    }
}
