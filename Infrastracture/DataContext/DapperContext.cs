using Npgsql;

namespace Infrastracture.DataContext;

public class DapperContext
{
    private readonly string _connectionString =
        "Host=localhost;Port=5432;Database=marketdb;User id=postgres;Password=akmaljon2008";

    public NpgsqlConnection Connection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}