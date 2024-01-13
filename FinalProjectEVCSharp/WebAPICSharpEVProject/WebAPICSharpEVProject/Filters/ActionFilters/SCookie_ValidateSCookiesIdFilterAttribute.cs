using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebAPICSharpEVProject.Models.Respositories;

namespace WebAPICSharpEVProject.Filters.ActionFilters
{
    public class SCookie_ValidateSCookiesIdFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var scookiesId = context.ActionArguments["id"] as int?;
            if (scookiesId.HasValue)
            {
                if (scookiesId.Value <= 0)
                {
                    context.ModelState.AddModelError("scookiesId", " scookiesId is invalid.");
                    context.Result = new BadRequestObjectResult(context.ModelState);
                }
                else if (!Repository.SCookieExists(scookiesId.Value))
                {
                    context.ModelState.AddModelError("scookiesId", " scookiesId does not exist.");
                    context.Result = new NotFoundObjectResult(context.ModelState);
                }
            }
        }
    }
}
