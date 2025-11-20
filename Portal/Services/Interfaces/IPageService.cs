namespace Portal.Services.Interfaces;

public interface IPageService
{
    Task<List<PageDto>> GetPages();
}