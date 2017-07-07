using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Epons.Api.Controllers
{
    public class BaseController : ApiController
    {
        protected void HasToBeAuthenticated()
        {
            if (Request.Properties.ContainsKey("jwt"))
            {
                return;
            }

            if (Request.Properties.ContainsKey("apikey"))
            {
                return;
            }

            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));

        }
    }
}
