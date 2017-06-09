using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.Infrastructure
{
    public class ProfileAttribute : ActionFilterAttribute
    {
        private Stopwatch time;

        public override void OnActionExecuting(ActionExecutingContext context){
            time = Stopwatch.StartNew();
        }

        public override void OnActionExecuted(ActionExecutedContext context){
            time.Stop();
            string result = "<div>Elapsed time:"
            + $"{time.Elapsed.TotalMilliseconds} ms </div>";

            byte[] bytes = Encoding.ASCII.GetBytes(result);
            context.HttpContext.Response.Body.Write(bytes, 0, bytes.Length);
        }
    }
}