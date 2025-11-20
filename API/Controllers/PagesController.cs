namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class PagesController(IRepository<PageEntity> pageRepository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetPages()
    {
        return Ok(await pageRepository.GetAllAsync());
    }
}
