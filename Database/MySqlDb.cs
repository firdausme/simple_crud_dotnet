using MySql.Data.MySqlClient;

namespace SimpleCrud.database;

public class MySqlDb : IDisposable
{
    public MySqlConnection? Connection;

    public MySqlDb(string connectionString)
    {
        try
        {
            Console.WriteLine($"Connecting to MySQL ...");
            Connection = new MySqlConnection(connectionString);
            Connection.Open();
            Console.WriteLine($"Connection established ...");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to connect to MySQL : {ex.Message}");
        }
    }

    public void Dispose()
    {
        if (Connection == null) return;

        Connection.Dispose();
        Connection = null;
        GC.SuppressFinalize(this);
    }
}