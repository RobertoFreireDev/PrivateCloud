namespace Portal.Pages;

public partial class Database : ComponentBase
{
    [Inject]
    public HttpClient Http { get; set; }

    public string content = "";

    private string ConsoleText = "";

    private async Task OnContentChanged(string value)
    {
        content = value;
    }

    private async Task OnSelectedContentChanged(string value)
    {
        return;
    }

    private async Task ExecuteFunction()
    {
        try
        {
            var response = await Http.PostAsJsonAsync<FunctionDto>("functions/run", new FunctionDto()
            {
                Name = "Temp",
                Content = content
            });

            response.EnsureSuccessStatusCode();
            var resultString = await response.Content.ReadAsStringAsync();
            ConsoleText = resultString;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}


