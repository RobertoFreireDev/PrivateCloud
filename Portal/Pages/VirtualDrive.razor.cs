namespace Portal.Pages;

public partial class VirtualDrive : ComponentBase
{
    [Inject]
    public IJSRuntime JS { get; set; }

    [Inject]
    public HttpClient Http { get; set; }

    private List<FileDto> files = new();

    protected override async Task OnInitializedAsync()
    {
        files = await Http.GetFromJsonAsync<List<FileDto>>("virtualdrive");
        StateHasChanged();
    }

    private async Task UploadFiles(IReadOnlyList<IBrowserFile> files)
    {
        foreach (var file in files)
        {
            var fileDto = await ConvertToFileDto(file);

            try
            {
                var response = await Http.PostAsJsonAsync("virtualdrive", fileDto);

                if (response.IsSuccessStatusCode)
                {
                    this.files.Add(fileDto);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    private async Task DownloadFile(FileDto file)
    {
        await JS.InvokeVoidAsync("downloadFileFromBase64", file.Name, file.Base64, file.ContentType);
    }

    private async Task DeleteFile(FileDto file)
    {
        try
        {
            var response = await Http.DeleteAsync($"virtualdrive/{file.Name}");

            if (response.IsSuccessStatusCode)
            {
                this.files.Remove(file);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private async Task<FileDto> ConvertToFileDto(IBrowserFile file)
    {
        var buffer = new byte[file.Size];
        await file.OpenReadStream().ReadExactlyAsync(buffer);
        var base64 = Convert.ToBase64String(buffer);
        return new FileDto()
        {
            Name = file.Name,
            Base64 = base64,
            ContentType = file.ContentType
        };
    }
}
