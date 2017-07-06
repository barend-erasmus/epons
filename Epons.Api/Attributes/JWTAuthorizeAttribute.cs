using Epons.Domain.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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


            base.OnActionExecuting(actionContext);
        }
    }

}