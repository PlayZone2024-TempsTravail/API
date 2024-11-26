using System.Data.Common;
using Dapper;
using Npgsql;
using PlayZone.DAL.Entities.Configuration_Related;
using PlayZone.DAL.Interfaces.Configuration_Related;

namespace PlayZone.DAL.Repositories.Configuration_Related;

public class ConfigurationRepository : IConfigurationRepository
{
    private readonly NpgsqlConnection _connection;

    public ConfigurationRepository(NpgsqlConnection connection)
    {
        this._connection = connection;
    }

    public IEnumerable<Configuration> GetAll()
    {
        const string query = @"
            SELECT
                 ""id_configuration"" AS IdConfiguration,
                ""date"" AS Date,
                ""parameter_name"" AS ParameterName,
                ""parameter_value"" AS ParameterValue
            FROM ""Configuration""
        ";
        return this._connection.Query<Configuration>(query);
    }

    public Configuration? GetById(int id)
    {
        const string query = @"
                SELECT
                    ""id_configuration"" AS ""IdConfiguration"",
                    ""date"" AS ""Date"",
                    ""parameter_name"" AS ""ParameterName"",
                    ""parameter_value"" AS ""ParameterValue""
                FROM ""Configuration""
                WHERE ""id_configuration"" = @IdConfiguration;
            ";
        //Configuration? config = this._connection.QueryFirstOrDefault<Configuration>(query, new { IdConfiguration = id });
        try
        {

        return this._connection.QueryFirstOrDefault<Configuration>(query, new { IdConfiguration = id });
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public int Create(Configuration configuration)
    {
        const string query = @"
                INSERT INTO ""Configuration"" (
                    ""date"",
                    ""parameter_name"",
                    ""parameter_value""
                )
                VALUES (
                    @Date,
                    @ParameterName,
                    @ParameterValue
                )
                RETURNING ""id_configuration"" AS ""IdConfiguration"";
            ";
        int resultId = this._connection.QuerySingle<int>(query, new
        {
            Date = configuration.Date,
            ParameterName = configuration.ParameterName,
            ParameterValue = configuration.ParameterValue
        });

        return resultId;
    }

    public bool Update(Configuration configuration)
    {
        const string query = @"
                UPDATE ""Configuration"" SET
                    ""date"" = @Date,
                    ""parameter_name"" = @ParameterName,
                    ""parameter_value"" = @ParamaterValue
                WHERE ""id_configuration"" = @IdConfiguration;
            ";
        int affectedRows = this._connection.Execute(query, new
        {
            IdConfiguration = configuration.IdConfiguration,
            Date = configuration.Date,
            ParameterName = configuration.ParameterName,
            ParameterValue = configuration.ParameterValue
        });
        return affectedRows > 0;
    }

    public bool Delete(int id)
    {
        const string query = @"DELETE FROM ""Configuration"" WHERE ""id_configuration"" = @IdConfiguration;";
        int affectedRows = this._connection.Execute(query, new { IdConfiguration = id });
        return affectedRows > 0;
    }
}
