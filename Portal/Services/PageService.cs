namespace Portal.Services;

public class PageService : IPageService
{
    public async Task<List<PageDto>> GetPages()
    {
        return await Task.FromResult(new List<PageDto>()
        {
            new PageDto { Name = "Home" },
            new PageDto { Name = "About" },
            new PageDto { Name = "Contact" }
        });
    }
}
