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
            await LoadPages();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void HandlePageSelected(PageDto page)
    {
    }

    private async Task HandlePageCreated(PageDto page)
    {
        try
        {
            await Http.PostAsJsonAsync<PageDto>("pages", page);
            await LoadPages();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private async Task LoadPages()
    {
        pages = await Http.GetFromJsonAsync<List<PageDto>>("pages");
    }
}
