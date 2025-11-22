namespace Portal.Components;

public partial class AceEditor : ComponentBase
{
    [Parameter]
    public string CodeContent { get; set; } = string.Empty;

    [Parameter]
    public string SelectedContent { get; set; } = string.Empty;

    [Parameter] 
    public string Style { get; set; } = string.Empty;

    [Parameter]
    public EventCallback<string> ContentChanged { get; set; }

    [Parameter]
    public string Mode { get; set; }

    [Inject]
    public IJSRuntime JS { get; set; }

    private DotNetObjectReference<AceEditor>? objRef;

    private bool _disposed = false;

    private ElementReference divElement;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await JS.InvokeVoidAsync("AceEditorInit", Mode);
        }
    }

    public async Task TriggerAceInstance()
    {
        objRef ??= DotNetObjectReference.Create(this);
        await JS.InvokeVoidAsync("GetCode", objRef, divElement);
    }

    [JSInvokable]
    public async Task ReceiveCode(string code)
    {
        CodeContent = code;
        await ContentChanged.InvokeAsync(CodeContent);
    }

    [JSInvokable]
    public async Task ReceiveSelectedCode(string selectedCode)
    {
        SelectedContent = selectedCode;
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                objRef?.Dispose();
            }
            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
