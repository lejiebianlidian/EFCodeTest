using EF6WithMiniProfiler.Models;
using StackExchange.Profiling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EF6WithMiniProfiler.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Department department=new Department();
            using (var context=new BlogDbContext())
            {
                var profiler = MiniProfiler.Current;
                using (profiler.Step("执行插入操作"))
                {
                    context.Departments.Add(new Department
                    {
                        Name = DepartmentNames.English,
                        Budget = 12.5M

                    });
                    context.SaveChanges();
                }

                using (profiler.Step("执行查询操作"))
                {
                    department = (from d in context.Departments
                                  where d.Name == DepartmentNames.English
                                  select d).FirstOrDefault();
                }


            }
            return View(department);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page121212.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.3434";

            return View();
        }
    }
}