namespace Portal.Components.Pages;

public partial class PageList : ComponentBase
{
    [Parameter]
    public List<PageDto> Pages { get; set; } = new();

    [Parameter]
    public EventCallback<PageDto> OnPageSelected { get; set; }

    private async Task SelectPage(PageDto page)
    {
        if (OnPageSelected.HasDelegate)
        {
            await OnPageSelected.InvokeAsync(page);
        }
    }
}
