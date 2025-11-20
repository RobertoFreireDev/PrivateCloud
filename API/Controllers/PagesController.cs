namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class PagesController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetPages()
    {
        try
        {
            return Ok(new List<PageDto>()
            {
                new PageDto { Name = "Home" },
                new PageDto { Name = "About" },
                new PageDto { Name = "Contact" }
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }
}
