namespace Portal.Pages;

public partial class Pages : ComponentBase
{
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

    private void HandlePageSelected(TItemDto item)
    {
    }

    private async Task HandlePageCreated(TItemDto item)
    {
        try
        {
            await Http.PostAsJsonAsync<PageDto>("pages", new PageDto()
            {
                Name = item.Name
            });
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
