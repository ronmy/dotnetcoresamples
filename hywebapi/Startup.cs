using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hywebapi.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;  


namespace hywebapi
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
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,  ILoggerFactory loggerFactory)
        {
            // 添加日志支持
            //loggerFactory.AddConsole();

            // 设置日志最小级别Warning
            loggerFactory.AddConsole(LogLevel.Warning);

            loggerFactory.AddDebug();   

            //  // 设置日志最小输出级别为Error
            //   loggerFactory.WithFilter(new FilterLoggerSettings()
            //   {
            //       // 设置以命名空间开头的日志的最小输出级别
            //       { "Microsoft", LogLevel.Warning },
            //      { "WebApiFrame", LogLevel.Error }
            //  }).AddConsole();     

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // 添加自定义中间件
            // app.UseMiddleware<HelloworldMiddleware>();
            // app.UseMiddleware<HelloworldTooMiddleware>();


            // 添加自定义中间件
            app.Map("/test", MapTest);

            // 添加自定义中间件
            app.MapWhen(context =>
            {
                return context.Request.Query.ContainsKey("a");
            }, 
            MapTest);


            // 添加自定义中间件
            app.Map("/level1", lv1App => {

                lv1App.Run(async context=>{
                    await context.Response.WriteAsync("Url is " + GetRequestInfo(context));
                });

                app.Map("/level1.1", lv11App => {
                    // /level1/level1.1
                    lv11App.Run(async context=>{
                        await context.Response.WriteAsync("Url is " + GetRequestInfo(context));
                    });

                });
                
                app.Map("/level1.2", lv12App => {
                    // /level1/level1.2
                    lv12App.Run(async context=>{
                    await context.Response.WriteAsync("Url is " + GetRequestInfo(context));
                    });
                });
            });


            app.UseMvc();
        }

        private static void MapTest(IApplicationBuilder app){
            app.Run(async context => {
                await context.Response.WriteAsync("Url is " + GetRequestInfo(context));
            });
        }
        private static String GetRequestInfo(HttpContext context)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(context.Request.Path.ToString());
            sb.AppendLine(context.Request.PathBase.ToString());
            sb.AppendLine(context.Request.QueryString.ToString());
            return sb.ToString();
        }
    }
}
