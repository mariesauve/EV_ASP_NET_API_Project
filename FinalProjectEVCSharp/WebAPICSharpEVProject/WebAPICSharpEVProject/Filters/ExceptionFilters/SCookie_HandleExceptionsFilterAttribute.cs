using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebAPICSharpEVProject.Models.Respositories;

namespace WebAPICSharpEVProject.Filters.ExceptionFilters
{
    public class SCookie_HandleExceptionsFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
            var strSCookieId = context.RouteData.Values["id"] as string;
            if (int.TryParse(strSCookieId, out int SCookieId))
            {
                if (!Repository.SCookieExists(SCookieId))
                {
                    context.ModelState.AddModelError("SCookieId", "Sugar Cookie does not exist anymore.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status404NotFound
                    };
                    context.Result = new NotFoundObjectResult(problemDetails);
                }

            }
        }
    }
}
