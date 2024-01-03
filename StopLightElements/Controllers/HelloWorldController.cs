using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace StopLightElements.Controllers;

/// <summary>
/// Hello world Controller
/// </summary>
[ApiController]
public class HelloWorldController : ControllerBase
{
    /// <summary>
    /// Hello world from Controller
    /// </summary>
    /// <remarks>
    /// Hello world from Controller
    /// </remarks>
    [HttpGet(ApiEndpoints.Hello.Controller)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public IResult Get([FromQuery, Required] string name)
    {
        return Results.Ok($"Hello {name}");
    }
}
