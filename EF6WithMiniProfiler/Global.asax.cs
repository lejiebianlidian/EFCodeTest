using StackExchange.Profiling;
using StackExchange.Profiling.EntityFramework6;
using StackExchange.Profiling.Mvc;
using StackExchange.Profiling.Storage;
using System;
using System.Data.SQLite;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace EF6WithMiniProfiler
{
    public class MvcApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// Gets the connection string.
        /// </summary>
        public static string ConnectionString => "FullUri=file::memory:?cache=shared";
        private static readonly SQLiteConnection TrapConnection = new SQLiteConnection(ConnectionString);

        protected void Application_Start()
        {

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            MiniProfiler.Configure(new MiniProfilerOptions().AddViewProfiling());//MiniProfilerĬ������
            MiniProfilerEF6.Initialize();//����EF����

        }

        /// <summary>
        /// ������Application_BeginRequest���������MiniProfiler��������
        /// </summary>
        protected void Application_BeginRequest()
        {
            MiniProfiler profiler = null;


            if (Request.IsLocal)
            {
                profiler = MiniProfiler.StartNew();

            }
            using (profiler.Step("Application_BeginRequest"))
            {
                //Todo
            }

        }

        /// <summary>
        /// ������Application_EndRequest���������MiniProfilerֹͣ����
        /// </summary>
        protected void Application_EndRequest()
        {

            MiniProfiler.Current?.Stop();

        }


    }
}
