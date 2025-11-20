namespace Portal.Pages;

public partial class Pages : ComponentBase
{
    [Parameter]
    public string? Name { get; set; }

    [Inject]
    public HttpClient Http { get; set; }

    private List<PageDto> pages { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        try
        {
            pages = await Http.GetFromJsonAsync<List<PageDto>>("pages");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching data: {ex.Message}");
        }
    }

    private void HandlePageSelected(PageDto page)
    {
        Console.WriteLine($"Selected page: {page.Name}");
    }
}
