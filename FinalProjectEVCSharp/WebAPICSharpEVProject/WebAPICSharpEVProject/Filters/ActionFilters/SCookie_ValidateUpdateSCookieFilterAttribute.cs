using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebAPICSharpEVProject.ActionFilters;
using WebAPICSharpEVProject.Models;
using SCookie_ValidateSCookieIdFilterAttribute.Models;

namespace WebAPICSharpEVProject.ActionFilters
{
    public class SCookie_ValidateUpdateSCookieFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var id = context.ActionArguments["id"] as int?;
            var scookies = context.ActionArguments["scookies"] as SugarCookies;

            if (id.HasValue && scookies != null && id != scookies.Id)
            {
                context.ModelState.AddModelError("SCookieId", " SCookieId is not the same as my id.");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }

        }
    }
}
