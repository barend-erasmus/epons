using Epons.Domain.Helpers;
using System;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Epons.Api.Attributes
{
    public class ResponseTimeAttribute : ActionFilterAttribute
    {
        private static UdpClient _udpClient = new UdpClient();

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

            stopwatch.Stop();

        }
    }
}