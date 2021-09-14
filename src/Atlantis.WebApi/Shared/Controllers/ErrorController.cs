namespace Atlantis.WebApi.Shared.Controllers
{
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using static Microsoft.AspNetCore.Http.StatusCodes;

    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("on-dev-env")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult ErrorOnDev([FromServices] IWebHostEnvironment webHostEnvironment)
        {
            if (webHostEnvironment.EnvironmentName != "Development")
                throw new InvalidOperationException("This shouldn't be invoked in non-development environments.");

            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error;
            while (exception.InnerException != null) exception = exception.InnerException;

            var problemDetails = new ProblemDetails
            {
                Title = exception.Message,
                Detail = exception.StackTrace,
                Status = Status500InternalServerError
            };

            return StatusCode(Status500InternalServerError, problemDetails);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Error() => StatusCode(Status500InternalServerError, new ProblemDetails());
    }
}
