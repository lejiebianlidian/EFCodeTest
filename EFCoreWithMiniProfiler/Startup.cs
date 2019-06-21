﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EFCoreWithMiniProfiler
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //services.AddMiniProfiler(options =>
            //{
            //    // All of this is optional. You can simply call .AddMiniProfiler() for all defaults

            //    // (Optional) Path to use for profiler URLs, default is /mini-profiler-resources
            //    options.RouteBasePath = "/profiler";

            //    // (Optional) Control storage
            //    // (default is 30 minutes in MemoryCacheStorage)
            //    (options.Storage as MemoryCacheStorage).CacheDuration = TimeSpan.FromMinutes(60);

            //    // (Optional) Control which SQL formatter to use, InlineFormatter is the default
            //    options.SqlFormatter = new StackExchange.Profiling.SqlFormatters.InlineFormatter();

            //    // (Optional) You can disable "Connection Open()", "Connection Close()" (and async variant) tracking.
            //    // (defaults to true, and connection opening/closing is tracked)
            //    options.TrackConnectionOpenClose = true;
            //});
            services.AddMiniProfiler()
                .AddEntityFramework();//注册AddMiniProfiler以及AddEntityFramework服务
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMiniProfiler();//添加服务.

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });


        }
    }
}
