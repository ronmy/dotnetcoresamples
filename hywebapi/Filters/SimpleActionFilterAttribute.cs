using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace hywebapi.Filters
{
    public class SimpleActionFilterAttribute : Attribute, IActionFilter
    {
        private readonly ILogger<SimpleActionFilterAttribute> logger;

        public SimpleActionFilterAttribute(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger<SimpleActionFilterAttribute>();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            logger.LogInformation("ActionFilter Executed!");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            logger.LogInformation("ActionFilter Executing!");
        }
    }
}
