namespace Portal.Pages;

public partial class VirtualDrive : ComponentBase
{
    [Inject]
    public IJSRuntime JS { get; set; }

    [Inject]
    public HttpClient Http { get; set; }

    private List<IBrowserFile> files = new();

    private async Task UploadFiles(IReadOnlyList<IBrowserFile> files)
    {
        foreach (var file in files)
        {
            this.files.Add(file);
        }
    }

    private async Task DownloadFile(IBrowserFile file)
    {
        var buffer = new byte[file.Size];
        await file.OpenReadStream().ReadAsync(buffer);
        var base64 = Convert.ToBase64String(buffer);
        await JS.InvokeVoidAsync("downloadFileFromBase64", file.Name, base64, file.ContentType);
    }
}
