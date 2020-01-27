using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Diagnostics;
using NLog;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BravoiSkill.API.Controllers
{
    public class ServerProblemDetails : ProblemDetails
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
    }

    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }

        [Route("error-local-development")]
        public IActionResult ErrorLocalDevelopment([FromServices] IHostingEnvironment webHostEnvironment)
        {
            try
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
                    Id = Guid.NewGuid(),
                    Status = (int)HttpStatusCode.InternalServerError,
                    Instance = feature?.Path,
                    Title = ex?.GetType().Name,
                    Message = ex.Message,
                    Detail = ex?.StackTrace,
                };
                Trace.CorrelationManager.ActivityId = serverProblemDetails.Id;
                // LogManager.Configuration.Variables["activityid"] = serverProblemDetails.Id;
                // GlobalDiagnosticsContext.Set("activityid", serverProblemDetails.Id);
                // MappedDiagnosticsLogicalContext.Set("activityid", serverProblemDetails.Id);
                // MappedDiagnosticsContext.Set("activityid", serverProblemDetails.Id);
                _logger.LogError(serverProblemDetails.Title + "|" + serverProblemDetails.Message + "|" + serverProblemDetails.Detail );
                return StatusCode(serverProblemDetails.Status.Value, serverProblemDetails);
            }
            catch(Exception ex)
            {
                Trace.CorrelationManager.ActivityId = Guid.NewGuid();
                // LogManager.Configuration.Variables["activityid"] = Guid.NewGuid();
                // GlobalDiagnosticsContext.Set("activityid", Guid.NewGuid());
                // MappedDiagnosticsLogicalContext.Set("activityid", Guid.NewGuid());
                // MappedDiagnosticsContext.Set("activityid", Guid.NewGuid());
                _logger.LogError(ex.ToLogString());
                return StatusCode(500, "Internal server error ");
            }
        }
 
        [Route("error")]
        public ActionResult Error([FromServices] IHostingEnvironment webHostEnvironment)
        {
            var feature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var ex = feature?.Error;
            var isDev = webHostEnvironment.IsDevelopment();
            var serverProblemDetails = new ServerProblemDetails
            {
                Id = Guid.NewGuid(),
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
