using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.Infrastructure
{
    public class ViewResultDiagnostics : IActionFilter
    {
        private IFilterDiagnostics diagnostics;

        public ViewResultDiagnostics(IFilterDiagnostics diag){
            diagnostics = diag;
        }

        public void OnActionExecuting(ActionExecutingContext context){
            //do nothing
        }

        public void OnActionExecuted(ActionExecutedContext context){
            ViewResult vr;
            if ((vr = context.Result as ViewResult) != null){
                diagnostics.AddMessage($"View name: {vr.ViewName}");
                diagnostics.AddMessage($@"Model type: {vr.ViewData.Model.GetType().Name}");
            }
        }
    }
}