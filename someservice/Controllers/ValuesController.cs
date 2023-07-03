using Microsoft.AspNetCore.Mvc;
using lib;

namespace someservice.Controllers;

[ApiController]
[Route("[controller]")]
public class ValuesController : ControllerBase
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly IMyResourceService _resourceService;

        public ValuesController(IMyResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] InputModel inputModel)
        {
            try
            {
                // Perform validation and processing
                if (!ModelState.IsValid)
                {
                    // Handle validation errors
                    var validationErrors = _resourceService.GetValidationErrors(ModelState);
                    return BadRequest(validationErrors);
                }

                // Process the input model
                // ...

                return Ok("Success");
            }
            catch (Exception ex)
            {
                // Handle exceptions
                string errorMessage = _resourceService.GetErrorMessage("SomeErrorKey");
                return StatusCode(500, errorMessage);
            }
        }
    }
}
