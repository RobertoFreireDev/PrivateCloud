namespace Portal.Pages;

public partial class Pages : ComponentBase
{
    [Inject]
    public IPageService pageService { get; set; }

    [Parameter]
    public string? Name { get; set; }

    private List<PageDto> pages { get; set; }

    protected override async Task OnInitializedAsync()
    {
        pages = await pageService.GetPages(); 
    }

    private void HandlePageSelected(PageDto page)
    {
        Console.WriteLine($"Selected page: {page.Name}");
    }
}
