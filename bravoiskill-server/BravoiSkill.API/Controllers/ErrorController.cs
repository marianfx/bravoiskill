using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BravoiSkill.API.Controllers
{
    public class ServerProblemDetails : ProblemDetails
    {
        public string Id { get; set; }
        public string Message { get; set; }
    }

    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class ErrorController : Controller
    {
        [Route("error-local-development")]
        public IActionResult ErrorLocalDevelopment([FromServices] IHostingEnvironment webHostEnvironment)
        {
            if (!webHostEnvironment.IsDevelopment())
            {
                throw new InvalidOperationException(
                    "This shouldn't be invoked in non-development environments.");
            }

            var feature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var ex = feature?.Error;

            var serverProblemDetails = new ServerProblemDetails
            {
                Id = Guid.NewGuid().ToString(),
                Status = (int)HttpStatusCode.InternalServerError,
                Instance = feature?.Path,
                Title = ex?.GetType().Name,
                Message = ex.Message,
                Detail = ex?.StackTrace,
            };

            return StatusCode(serverProblemDetails.Status.Value, serverProblemDetails);
        }

        [Route("error")]
        public ActionResult Error([FromServices] IHostingEnvironment webHostEnvironment)
        {
            var feature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var ex = feature?.Error;
            var isDev = webHostEnvironment.IsDevelopment();
            var serverProblemDetails = new ServerProblemDetails
            {
                Id = Guid.NewGuid().ToString(),
                Status = (int)HttpStatusCode.InternalServerError,
                Instance = feature?.Path,
                Title = isDev ? $"{ex.GetType().Name}: {ex.Message}" : "An error occurred.",
                Message = ex.Message,
                Detail = isDev ? ex.StackTrace : null,
            };

            return StatusCode(serverProblemDetails.Status.Value, serverProblemDetails);
        }
    }
}
