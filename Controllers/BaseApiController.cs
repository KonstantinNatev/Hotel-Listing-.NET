using System.Linq;
using HotelListing.api.Results;
using Microsoft.AspNetCore.Mvc;

namespace HotelListing.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public abstract class BaseApiController : ControllerBase
{
    protected ActionResult<T> ToActionResult<T>(Result<T> result)
        => result.IsSuccess ? Ok(result.Value) : MapErrorToActionResult(result.Errors);

    protected ActionResult ToActionResult(Result result)
        => result.IsSuccess ? NoContent() : MapErrorToActionResult(result.Errors);

    protected ActionResult MapErrorToActionResult(Error[] errors)
    {
        if (errors is null || errors.Length == 0)
        {
            return Problem();
        }

        var error = errors[0];

        return error.Code switch
        {
            "NotFound" => NotFound(error.Description),
            "Conflict" => Conflict(error.Description),
            "Validation" => BadRequest(error.Description),
            "BadRequest" => BadRequest(error.Description),
            _ => Problem(detail: string.Join("; ", errors.Select(x => x.Description)), title: error.Code)
        };
    }
}