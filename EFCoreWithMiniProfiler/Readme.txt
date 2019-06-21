1、安装MiniProfiler.AspNetCore.Mvc 以及MiniProfiler.EntityFrameworkCore
2、编辑Startup.cs文件，在ConfigureServices方法中注入MiniProfiler以及EntityFramework服务；services.AddMiniProfiler().AddEntityFramework();
3、在Configure方法中配置服务项app.UseMiniProfiler().(该项要配置在app.AddMvc()之前)
4、_ViewImports.cshtml文件中增加Tag Helpers:
@using StackExchange.Profiling
@addTagHelper *, MiniProfiler.AspNetCore.Mvc
5、在_Layout.cshtml页面中添加MiniProfiler 标签：
<mini-profiler />或者
<mini-profiler position="RenderPosition.Left" show-trivial="true" show-time-with-children="true" show-controls="false" start-hidden="false" />
2019-06-21 