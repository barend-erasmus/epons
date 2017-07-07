using Epons.Domain.Helpers;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Epons.Api.Attributes
{
    public class JWTAuthorizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
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
                string apikey = actionContext.Request.Headers.GetValues("apikey").ToString();

                if (apikey == "2c0d64c1-d002-45f2-9dc4-784c24e996")
                {
                    actionContext.Request.Properties["apikey"] = actionContext.Request.Headers.GetValues("apikey").ToString();
                }
            }


            base.OnActionExecuting(actionContext);
        }
    }

}