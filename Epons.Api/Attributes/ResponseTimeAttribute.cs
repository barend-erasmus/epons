using Epons.Domain.Helpers;
using StatsdClient;
using System;
using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Epons.Api.Attributes
{
    public class ResponseTimeAttribute : ActionFilterAttribute
    {
        private const string Key = "ResponseTimeAttribute";

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);

            actionContext.Request.Properties[Key] = System.Diagnostics.Stopwatch.StartNew();
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);

            System.Diagnostics.Stopwatch stopwatch = (System.Diagnostics.Stopwatch)actionExecutedContext.Request.Properties[Key];

            Metrics.Timer("HTTPResponseTime", Convert.ToInt32(stopwatch.ElapsedMilliseconds));
        }
    }
}