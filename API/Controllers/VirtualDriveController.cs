namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class VirtualDriveController(IRepository<FileEntity> fileRepository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetFiles()
    {
        return Ok(await fileRepository.GetAllAsync());
    }

    [HttpPost]
    public async Task<IActionResult> CreateFile(FileDto request)
    {
        return Ok(await fileRepository
            .CreateAsync(new FileEntity()
            {
                Name = request.Name,
                Base64 = request.Base64,
                ContentType = request.ContentType
            }));
    }
}