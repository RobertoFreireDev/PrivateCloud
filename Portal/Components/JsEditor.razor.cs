namespace Portal.Components;

public partial class JsEditor : ComponentBase
{
    [Parameter]
    public string CodeContent { get; set; }

    [Inject]
    public IJSRuntime JS { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await JS.InvokeVoidAsync("AceEditorInit");
        }
    }
}
