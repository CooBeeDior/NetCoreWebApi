using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCoreWebApi.Model;
using StackExchange.Profiling;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace NetCoreWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //负责注入服务
        public void ConfigureServices(IServiceCollection services)
        {
            //获取数据库连接字符串
            var connectionStrings = Configuration.GetConnectionString("SqlServer");
            services.AddDbContext<MyDbContext>
            (options => options.UseSqlServer(connectionStrings,
                e => e.MigrationsAssembly("NetCoreWebApi.Model")));
            //注入Swagger服务
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new Info
                    {
                        Version = "v1",
                        Title = "在线接口文档",
                        Description = "一个简单的例子",
                        Contact = new Contact { Name = "TengHao", Email = "tenghao510@qq.com" },
                        License = new License { Name = "TengHao", Url = "https://blog.csdn.net/weixin_37291339" }
                    });

                // 为 Swagger JSON and UI设置xml文档注释路径
                var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);//获取应用程序所在目录
                var xmlPath01 = Path.Combine(basePath, "NetCoreWebApi.xml"); 
                options.IncludeXmlComments(xmlPath01, true);
                var xmlPath = Path.Combine(basePath, "NetCoreWebApi.Model.xml"); 
                options.IncludeXmlComments(xmlPath);
            });
            // 首先添加一个配置选项，用于访问分析结果：
            services.AddMiniProfiler(options =>
            {
                // 设定弹出窗口的位置
                options.PopupRenderPosition = RenderPosition.Left;
                // 设定在弹出的明细窗口里会显式Time With Children这列
                options.PopupShowTimeWithChildren = true;
                // 设定访问分析结果URL的路由基地址
                options.RouteBasePath = "/profiler";
            }).AddEntityFramework();//显示sql
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // 响应 HTTP 请求的方式。可将中间件注册到IApplicationBuilder 实例来配置请求管道。
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //启用Swagger服务
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.DefaultModelsExpandDepth(-1); //设置为 - 1 可不显示models
                c.DocExpansion(DocExpansion.None);//设置为none可折叠所有方法
            });
            //把它放在UseMvc()方法之前。 
            app.UseMiniProfiler();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
        }
    }
}
