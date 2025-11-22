namespace Portal.Pages;

public partial class Database : ComponentBase
{
    [Inject]
    public HttpClient Http { get; set; }

    public string content = string.Empty;

    private string consoleText = string.Empty;

    private bool loading = false;

    private async Task OnContentChanged(string value)
    {
        content = value;
    }

    private async Task ExecuteFunction()
    {
        try
        {
            loading = true;
            StateHasChanged();
            var response = await Http.PostAsJsonAsync<FunctionDto>("functions/run", new FunctionDto()
            {
                Name = "Temp",
                Content = content
            });

            response.EnsureSuccessStatusCode();
            var resultString = await response.Content.ReadAsStringAsync();
            consoleText = resultString;
            loading = false;
            StateHasChanged();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}


