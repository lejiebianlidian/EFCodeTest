using StackExchange.Profiling;
using StackExchange.Profiling.EntityFramework6;
using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace EF6WithMiniProfiler
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {


            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
#if DEBUG
            MiniProfilerEF6.Initialize();
#endif
        }

        protected void Application_BeginRequest(object source, EventArgs args)
        {
#if DEBUG
            if (Request.IsLocal)
            {
                MiniProfiler.StartNew();

            }
#endif
        }

        protected void Application_EndRequest()
        {
#if DEBUG
            MiniProfiler.Current?.Stop();//
#endif
        }

    }
}
