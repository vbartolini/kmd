using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace KmdProject.Api.Infrastructure
{
    public class ResponseTimeActionFilter : IActionFilter
    {
        private const string ActionResponseTimeKey = "Action-Response-Time";
        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Items[ActionResponseTimeKey] = Stopwatch.StartNew();
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Stopwatch stopwatch = (Stopwatch)context.HttpContext.Items[ActionResponseTimeKey];
            var timeElapsed = stopwatch.Elapsed;
            context.HttpContext.Response.Headers.Add(ActionResponseTimeKey, $"{timeElapsed.Milliseconds} ms");
        }
    }
}
