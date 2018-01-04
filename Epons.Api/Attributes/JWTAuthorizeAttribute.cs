using Epons.Domain.Helpers;
using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Epons.Api.Attributes
{
    public class JWTAuthorizeAttribute : ActionFilterAttribute
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            _logger.Info($"Request - {actionContext.Request.RequestUri.PathAndQuery}");

            if (actionContext.Request.Headers.Authorization != null && actionContext.Request.Headers.Authorization.Scheme.ToLower() == "bearer")
            {
                string jwt = actionContext.Request.Headers.Authorization.Parameter;

                if (Crypto.ValidateJWT(jwt))
                {
                    actionContext.Request.Properties["jwt"] = jwt;
                }
            }

            if (actionContext.Request.Headers.Contains("apikey"))
            {
                string apikey = actionContext.Request.Headers.GetValues("apikey").First().ToString();

                if (apikey == "2c0d64c1-d002-45f2-9dc4-784c24e996")
                {
                    actionContext.Request.Properties["apikey"] = actionContext.Request.Headers.GetValues("apikey").ToString();
                }
            }


            base.OnActionExecuting(actionContext);
        }
    }

}