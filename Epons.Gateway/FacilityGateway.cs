using Epons.Gateway.Models;
using RestSharp;
using System;
using System.Net;

namespace Epons.Gateway
{
    public class FacilityGateway
    {
        private readonly string _endpoint = "http://api.sadfm.co.za";
        private readonly string _apikey = "2c0d64c1-d002-45f2-9dc4-784c24e996";

        public FacilityDto Find(Guid id)
        {
            RestClient client = new RestClient(_endpoint);

            RestRequest request = new RestRequest("api/Facility/FindById", Method.GET);

            request.AddHeader("apikey", _apikey);

            request.AddParameter("id", id);

            IRestResponse<FacilityDto> response = client.Execute<FacilityDto>(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return null;
            }

            return response.Data;
        }

        public bool Lock(Guid id)
        {
            RestClient client = new RestClient(_endpoint);

            RestRequest request = new RestRequest("api/Facility/Lock", Method.GET);

            request.AddHeader("apikey", _apikey);

            request.AddParameter("id", id);

            IRestResponse<bool> response = client.Execute<bool>(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return false;
            }

            return response.Data;
        }

        public bool Unlock(Guid id)
        {
            RestClient client = new RestClient(_endpoint);

            RestRequest request = new RestRequest("api/Facility/Lock", Method.GET);

            request.AddHeader("apikey", _apikey);

            request.AddParameter("id", id);

            IRestResponse<bool> response = client.Execute<bool>(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return false;
            }

            return response.Data;
        }
    }
}
