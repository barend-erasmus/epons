using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Epons.Gateway
{
    public class ValidationGateway
    {
        private readonly string _endpoint = "http://api.sadfm.co.za";
        private readonly string _apikey = "2c0d64c1-d002-45f2-9dc4-784c24e996";

        public bool IdentificationNumber(string identificationNumber)
        {
            RestClient client = new RestClient(_endpoint);

            RestRequest request = new RestRequest("api/Validator/IdentificationNumber", Method.GET);

            request.AddHeader("apikey", _apikey);

            request.AddParameter("identificationNumber", identificationNumber);

            IRestResponse<bool> response = client.Execute<bool>(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return false;
            }

            return response.Data;
        }

        public bool IsMale(string identificationNumber)
        {
            RestClient client = new RestClient(_endpoint);

            RestRequest request = new RestRequest("api/Validator/IsMale", Method.GET);

            request.AddHeader("apikey", _apikey);

            request.AddParameter("identificationNumber", identificationNumber);

            IRestResponse<bool> response = client.Execute<bool>(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return false;
            }

            return response.Data;
        }

        public bool IsFemale(string identificationNumber)
        {
            RestClient client = new RestClient(_endpoint);

            RestRequest request = new RestRequest("api/Validator/IsFemale", Method.GET);

            request.AddHeader("apikey", _apikey);

            request.AddParameter("identificationNumber", identificationNumber);

            IRestResponse<bool> response = client.Execute<bool>(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return false;
            }

            return response.Data;
        }

        public DateTime? DateOfBirth(string identificationNumber)
        {
            RestClient client = new RestClient(_endpoint);

            RestRequest request = new RestRequest("api/Validator/DateOfBirth", Method.GET);

            request.AddHeader("apikey", _apikey);

            request.AddParameter("identificationNumber", identificationNumber);

            IRestResponse<DateTime> response = client.Execute<DateTime>(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return null;
            }

            return response.Data;
        }
    }
}
