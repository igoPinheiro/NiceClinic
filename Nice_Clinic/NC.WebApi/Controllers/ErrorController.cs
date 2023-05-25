using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NC.Core.Shared.ModelViews;
using System.Diagnostics;

namespace NC.WebApi.Controllers;

[ApiExplorerSettings(IgnoreApi =true)]
[ApiController]
public class ErrorController : ControllerBase
{
    [Route("Error")]
    public ErrorResponse Error()
    {
        var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
        var excpetion = context?.Error;

        Response.StatusCode = 500;

        var idError = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
        return new ErrorResponse(idError ?? Guid.NewGuid().ToString(), HttpContext?.TraceIdentifier ?? string.Empty);
    }
}
