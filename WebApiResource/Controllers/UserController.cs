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
        // throw new HttpRequestException("", null, HttpStatusCode.Forbidden);
        return Ok(userModel);
    }
}
