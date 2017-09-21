using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace hywebapi.Filters
{
    public class MyActionFilterAttribute : Attribute, IActionFilter
    {
        private readonly ILogger<MyActionFilterAttribute> logger;

        public MyActionFilterAttribute(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger<MyActionFilterAttribute>();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add("My-Header", "WebApiFrame-Header");
        }
    }
}