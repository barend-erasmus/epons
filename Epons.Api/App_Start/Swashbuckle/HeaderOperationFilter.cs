using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;

namespace Epons.Api.App_Start.Swashbuckle
{
    public class HeaderOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            operation.parameters.Add(new Parameter()
            {
                description = "JSON Web Token",
                @in = "header",
                name = "Authorization",
                required = false
            });
        }
    }
}