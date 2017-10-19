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

            SendMetric("HTTPResponseTime", stopwatch.ElapsedMilliseconds, "ms", new string[][] {
                new string[]
                {
                    "Token",
                    "eea9d4b1-9e49-4a8d-9e6d-f65ac51818c2"
                },
                new string[]
                {
                    "Application",
                    "EPONSAPI"
                },
                new string[]
                {
                    "Controller",
                    actionExecutedContext.ActionContext.ActionDescriptor.ControllerDescriptor.ControllerName
                },
                new string[]
                {
                    "Action",
                    actionExecutedContext.ActionContext.ActionDescriptor.ActionName
                },
                new string[]
                {
                    "Method",
                    actionExecutedContext.Request.Method.ToString()
                },
                new string[]
                {
                    "StatusCode",
                    actionExecutedContext.Response.StatusCode.ToString()
                }
            });

            SendMetric("HTTPRequest", 1, "c", new string[][] {
                new string[]
                {
                    "Token",
                    "eea9d4b1-9e49-4a8d-9e6d-f65ac51818c2"
                },
                new string[]
                {
                    "Application",
                    "EPONSAPI"
                },
                new string[]
                {
                    "Controller",
                    actionExecutedContext.ActionContext.ActionDescriptor.ControllerDescriptor.ControllerName
                },
                new string[]
                {
                    "Action",
                    actionExecutedContext.ActionContext.ActionDescriptor.ActionName
                },
                new string[]
                {
                    "Method",
                    actionExecutedContext.Request.Method.ToString()
                },
                new string[]
                {
                    "StatusCode",
                    actionExecutedContext.Response.StatusCode.ToString()
                }
            });
        }

        private void SendMetric(string name, long value, string type, string[][] tags)
        {
            _udpClient.Connect("open-stats.openservices.co.za", 8125);

            string tagsString = String.Join(",", tags.Select((x) => $"{x[0]}:{x[1]}").ToArray());

            byte[] bytes = Encoding.ASCII.GetBytes($"{name}:{value}|{type}|#{tagsString}");

            _udpClient.Send(bytes, bytes.Length);
        }
    }
}