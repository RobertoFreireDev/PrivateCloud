namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class FunctionsController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Set([FromBody] FunctionDto request)
    {
        try
        {
            return Ok(request);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }
}
