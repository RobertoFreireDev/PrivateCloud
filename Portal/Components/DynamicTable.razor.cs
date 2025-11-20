namespace Portal.Components;

public partial class DynamicTable : ComponentBase
{
    [Parameter]
    public string JsonString { get; set; }

    private List<Dictionary<string, object?>> rows = new();
    private List<string> columns = new();

    protected override void OnParametersSet()
    {
        ParseJson();
    }

    private void ParseJson()
    {
        rows.Clear();
        columns.Clear();

        if (string.IsNullOrWhiteSpace(JsonString))
            return;

        try
        {
            using var doc = JsonDocument.Parse(JsonString);
            if (doc.RootElement.ValueKind == JsonValueKind.Array)
            {
                foreach (var element in doc.RootElement.EnumerateArray())
                {
                    var dict = new Dictionary<string, object?>();
                    foreach (var prop in element.EnumerateObject())
                    {
                        dict[prop.Name] = prop.Value.ValueKind switch
                        {
                            JsonValueKind.String => prop.Value.GetString(),
                            JsonValueKind.Number => prop.Value.GetDouble(),
                            JsonValueKind.True => true,
                            JsonValueKind.False => false,
                            _ => prop.Value.ToString()
                        };

                        if (!columns.Contains(prop.Name))
                            columns.Add(prop.Name);
                    }
                    rows.Add(dict);
                }
            }
        }
        catch (JsonException)
        {
            rows.Clear();
            columns.Clear();
        }
    }
}