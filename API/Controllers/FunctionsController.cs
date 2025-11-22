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

    [HttpPost("run")]
    public async Task<IActionResult> Execute([FromBody] FunctionDto request)
    {
        using var db = new SqliteHelper(ApiConfig.CustomDb);
        return Ok(db.ExecuteReader(request.Content));
    }
}
