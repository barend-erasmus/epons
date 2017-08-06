using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Epons.Domain.Repositories;
using Epons.Domain.Services;
using Epons.Domain.Validators;
using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Epons.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<PatientRepository>().As<PatientRepository>();
            builder.RegisterType<PatientService>().As<PatientService>();
            builder.RegisterType<UserRepository>().As<UserRepository>();
            builder.RegisterType<UserService>().As<UserService>();
            builder.RegisterType<VisitRepository>().As<VisitRepository>();
            builder.RegisterType<VisitService>().As<VisitService>();
            builder.RegisterType<EpisodeOfCareRepository>().As<EpisodeOfCareRepository>();
            builder.RegisterType<EpisodeOfCareService>().As<EpisodeOfCareService>();
            builder.RegisterType<RSAIdentificationNumberValidator>().As<RSAIdentificationNumberValidator>();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);


            // GlobalConfiguration.Configuration.EnableSwagger(c => c.SingleApiVersion("v1", "A title for your API")).EnableSwaggerUi();
        }
    }
}
