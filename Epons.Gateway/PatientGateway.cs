using Epons.Gateway.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Epons.Gateway
{
    public class PatientGateway
    {

        private readonly string _endpoint = "http://api.sadfm.co.za";
        private readonly string _apikey = "2c0d64c1-d002-45f2-9dc4-784c24e996";

        public PatientDto Find(Guid id)
        {
            RestClient client = new RestClient(_endpoint);

            RestRequest request = new RestRequest("api/Patient/FindById", Method.GET);

            request.AddHeader("apikey", _apikey);

            request.AddParameter("id", id);

            IRestResponse<PatientDto> response = client.Execute<PatientDto>(request);
            
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return null;
            }    

            return response.Data;
        }

        public PatientDto Find(string identificationNumber)
        {
            RestClient client = new RestClient(_endpoint);

            RestRequest request = new RestRequest("api/Patient/FindByIdentificationNumber", Method.GET);

            request.AddHeader("apikey", _apikey);

            request.AddParameter("identificationNumber", identificationNumber);

            IRestResponse<PatientDto> response = client.Execute<PatientDto>(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return null;
            }

            return response.Data;
        }

        public PatientDto Find(string firstname, string lastname, DateTime dateOfBirth)
        {
            RestClient client = new RestClient(_endpoint);

            RestRequest request = new RestRequest("api/Patient/FindByDetails", Method.GET);

            request.AddHeader("apikey", _apikey);

            request.AddParameter("firstname", firstname);
            request.AddParameter("lastname", lastname);
            request.AddParameter("dateOfBirth", dateOfBirth);

            IRestResponse<PatientDto> response = client.Execute<PatientDto>(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return null;
            }

            return response.Data;
        }
    }
}
