using Microsoft.AspNetCore.Mvc.Filters;

namespace mvc_resultats_typer.ActionFilters
{
    public class CustomStringFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Items["CustomMessage"] = "This is a custom message with Action Filter.";
            base.OnActionExecuting(context);

            Console.WriteLine("CustomStringFilterAttribute executed.");
        }
    }
}
