using System.Net;
using Microsoft.AspNetCore.Mvc;
using WebApiResource.Models;

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
            // throw new HttpRequestException("", null, HttpStatusCode.NotFound);
            return Ok(userModel);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
