using Microsoft.AspNetCore.Mvc;
using WebApiResource.Models;
using WebApiResource.Resources;

namespace WebApiResource.Controllers;

[ApiController]
[Route("api/v1/users")]
public class UserController : ControllerBase
{

    public UserController()
    {
    }

    [HttpPost]
    public IActionResult Post([FromBody] User userModel)
    {
        try
        {
            return Ok(userModel);
        }
        catch (Exception ex)
        {
            var statusCode = GetHttpStatusCodeFromException(ex);

            var errorMessage = ErrorMessages.ResourceManager.GetString(name: $"{statusCode}");
            return StatusCode(statusCode, errorMessage);
        }

    }
    private static int GetHttpStatusCodeFromException(Exception ex)
    {
        if (ex is HttpRequestException httpRequestException)
        {
            if (httpRequestException.StatusCode.HasValue)
            {
                return (int)httpRequestException.StatusCode.Value;
            }
        }
        return 500;
    }
}
