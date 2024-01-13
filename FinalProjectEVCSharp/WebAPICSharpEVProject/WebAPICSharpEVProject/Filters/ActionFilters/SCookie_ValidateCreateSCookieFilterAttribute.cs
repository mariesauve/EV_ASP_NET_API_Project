using WebAPICSharpEVProject.Models.Respositories;
using WebAPICSharpEVProject.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using SCookie_ValidateSCookieIdFilterAttribute.Models;

namespace WebAPICSharpEVProject.Filters.ActionFilters
{
    public class SCookie_ValidateCreateSCookieFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);


            var scookies = context.ActionArguments["scookies"] as SugarCookies;
            if (scookies == null)
            {
                context.ModelState.AddModelError("SugarCookies", " SCookie object is null");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
            else
            {
                var existingSCookie = Repository.GetSCookieByProperties(scookies.Flavour, scookies.CType, scookies.Size, scookies.Price);
                if (existingSCookie != null)
                {
                    context.ModelState.AddModelError("SugarCookies", " SCookie object is null.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
            }

        }

    }
}

