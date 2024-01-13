using Microsoft.AspNetCore.Mvc;
using WebAPICSharpEVProject.Models.Respositories;
using WebAPICSharpEVProject.Filters.ActionFilters;
using WebAPICSharpEVProject.Models;
using WebAPICSharpEVProject.ActionFilters;

using WebAPICSharpEVProject.Filters.ExceptionFilters;


namespace WebAPICSharpEVProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [SCookie_HandleExceptionsFilter]


    public class SCookieController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetSCookies()
        {
            return Ok(Repository.GetSCookies());
        }

        [HttpGet("{id}")]
        [SCookie_HandleExceptionsFilter]
        [SCookie_ValidateSCookiesIdFilter]
        public IActionResult GetSCookieById(int id)
        {
            return Ok(Repository.GetSCookieById(id));
        }
        [HttpPost()]
        public IActionResult CreateCookie([FromForm] SugarCookies scookies)
        {
            Repository.AddSCookie(scookies);
            return CreatedAtAction(nameof(GetSCookieById),
                new { id = scookies.Id },
                scookies);
        }

        [HttpPut("{id}")]
        [SCookie_ValidateUpdateSCookieFilter]
        [SCookie_ValidateSCookiesIdFilter]
        public IActionResult UpdateSCookie(int id, SugarCookies scookies)
        {

            Repository.UpdateSCookie(scookies);
            return NoContent();
        }
        [HttpDelete("{id}")]
        [SCookie_ValidateSCookiesIdFilter]
        public IActionResult DeleteSugarCookie(int id)
        {
            var scookies = Repository.GetSCookieById(id);
            Repository.DeleteSCookie(id);
            return Ok(scookies);
        }
    }
}
