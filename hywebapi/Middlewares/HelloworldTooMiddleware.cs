using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace hywebapi.Middlewares
{
    public class HelloworldTooMiddleware
    {
        private readonly RequestDelegate _next;

        public HelloworldTooMiddleware(RequestDelegate next){
            _next = next;
        }

        public async Task Invoke(HttpContext context){
            await context.Response.WriteAsync("Hello World too!");
        }
    }
}

