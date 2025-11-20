namespace API.db;

public class SqliteConfig
{
    public string DatabasePath { get; }

    public SqliteConfig(string databasePath)
    {
        DatabasePath = databasePath;
    }

    public string GetConnectionString()
    {
        return $"Data Source={DatabasePath};";
    }
}
