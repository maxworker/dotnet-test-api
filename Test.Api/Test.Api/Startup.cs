using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Test.Api.Startup))]

namespace Test.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Run(context =>
            {
                context.Response.ContentType = "text/html; charset=utf-8";
                return context.Response.WriteAsync("Test");
            });
        }
    }
}
