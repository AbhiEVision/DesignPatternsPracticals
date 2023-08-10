using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;

namespace DesignPatterns.API.Attribute
{
	public class LogAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			string actionName = ((ControllerActionDescriptor)context.ActionDescriptor).ActionName;
			var parameters = context.ActionArguments.Select(a => new { val = a.Value.ToString() }).Select(x => x.val).FirstOrDefault();
			Log.ForContext<LogAttribute>().Information($"{context.Controller.GetType().Name}/{actionName}/{parameters}");
		}
	}
}
