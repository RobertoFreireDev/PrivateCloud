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
        var outputLines = new List<string>();
        var config = new SqliteConfig("mydatabase.db");

        using var db = new SqliteHelper(config);
        return Ok(db.ExecuteReader(request.Content));
    }
}
