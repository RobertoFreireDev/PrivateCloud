namespace Portal.Components.Pages;

public partial class PageList : ComponentBase
{
    [Parameter]
    public List<PageDto> Pages { get; set; } = new();

    [Parameter]
    public EventCallback<PageDto> OnPageSelected { get; set; }

    [Parameter]
    public EventCallback<PageDto> OnPageCreated { get; set; }

    private string NewPageName = string.Empty;

    private async Task SelectPage(PageDto page)
    {
        if (OnPageSelected.HasDelegate)
        {
            await OnPageSelected.InvokeAsync(page);
        }
    }

    private async Task CreatePage()
    {
        if (string.IsNullOrWhiteSpace(NewPageName))
            return;

        if (OnPageCreated.HasDelegate)
        {
            await OnPageCreated.InvokeAsync(new PageDto { Name = NewPageName });
        }

        NewPageName = string.Empty;
    }
}
