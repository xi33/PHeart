using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Domain.Authentication;
using Domain.Repositories;
using StackExchange.Profiling;

namespace WebUI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {

        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            //auto-register compared to Ninejct
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            //Domain
            builder.RegisterModule(new MoqRepositoriesModule());
            //builder.RegisterModule(new RepositoriesModule());

            //Domain Authentication
            builder.RegisterModule(new AuthenticationModule());

            return builder.Build();

        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_BeginRequest()
        {
            if (Request.IsLocal)
            {
                MiniProfiler.Start();
            }
        }

        //protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        //{
        //    if (!Request.IsAuthenticated)
        //    {
        //        MiniProfiler.Stop(discardResults: true);
        //    }
        //}

        protected void Application_Start()
        {
            //Autofac
            var container = BuildContainer();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();

            // Use LocalDB for Entity Framework by default
            Database.DefaultConnectionFactory = new SqlConnectionFactory(@"Data Source=(localdb)\v11.0; Integrated Security=True; MultipleActiveResultSets=True");

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_EndRequest()
        {
            MiniProfiler.Stop();
        }
    }
}