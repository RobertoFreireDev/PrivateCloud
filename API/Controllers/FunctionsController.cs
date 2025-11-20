namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class FunctionsController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Set([FromBody] FunctionDto request)
    {
        return Ok(request);
    }
}
