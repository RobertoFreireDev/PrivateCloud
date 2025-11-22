namespace API.db;

public class SqliteHelper : IDisposable
{
    private readonly SqliteConnection _connection;

    public SqliteHelper(string connectionString)
    {
        _connection = new SqliteConnection(connectionString);
        _connection.Open();
    }

    public string ExecuteReader(string sql)
    {
        try
        {
            using var cmd = new SqliteCommand(sql, _connection);
            var reader = cmd.ExecuteReader();
            var rows = new List<Dictionary<string, object>>();

            while (reader.Read())
            {
                var row = new Dictionary<string, object>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    row[reader.GetName(i)] = reader.GetValue(i);
                }
                rows.Add(row);
            }
            return JsonSerializer.Serialize(rows);
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public void Dispose()
    {
        _connection?.Close();
        _connection?.Dispose();
    }
}