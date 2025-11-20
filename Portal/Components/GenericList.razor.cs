namespace Portal.Components;

public partial class GenericList : ComponentBase
{
    [Parameter]
    public List<TItemDto> Items { get; set; } = new();

    [Parameter]
    public EventCallback<TItemDto> OnItemSelected { get; set; }

    [Parameter]
    public EventCallback<TItemDto> OnItemCreated { get; set; }


    private string NewItemName = string.Empty;

    private async Task SelectItem(TItemDto item)
    {
        if (OnItemSelected.HasDelegate)
        {
            await OnItemSelected.InvokeAsync(item);
        }
    }

    private async Task CreateItem()
    {
        if (string.IsNullOrWhiteSpace(NewItemName))
            return;

        if (OnItemCreated.HasDelegate)
        {
            await OnItemCreated.InvokeAsync(new TItemDto() { Name = NewItemName });
        }

        NewItemName = string.Empty;
    }
}
