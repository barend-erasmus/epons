using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Epons.Gateway
{
    public class SettingGateway
    {
        private readonly string _endpoint = "http://api.sadfm.co.za";
        private readonly string _apikey = "2c0d64c1-d002-45f2-9dc4-784c24e996";

        public string Find(string name)
        {
            RestClient client = new RestClient(_endpoint);

            RestRequest request = new RestRequest("api/Setting/Find", Method.GET);

            request.AddHeader("apikey", _apikey);

            request.AddParameter("name", name);

            IRestResponse response = client.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return null;
            }

            return response.Content.Trim('"');
        }

        public void Update(string name, string value)
        {
            RestClient client = new RestClient(_endpoint);

            RestRequest request = new RestRequest("api/Setting/Update", Method.GET);

            request.AddHeader("apikey", _apikey);

            request.AddParameter("name", name);
            request.AddParameter("value", value);

            IRestResponse response = client.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Gateway Request Failed");
            }
        }
    }
}
