using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject;
using Ninject.Web.Mvc;
using DependencyResolver;

namespace MvcPL
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            IKernel resolver = new StandardKernel();
            resolver.ConfigurateResolverWeb();
            System.Web.Mvc.DependencyResolver.SetResolver(new NinjectDependencyResolver(resolver));
            
        }

        protected void Application_Error()
        {
            Response.Redirect("Error/ApplicationError");
            //TODO in logger
            //var error = Server.GetLastError();
            //Response.ContentType = "text/plain";
            //Response.Write(error ?? (object)"unknown");
            //Response.End();
        } 
    }
}
