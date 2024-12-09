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
                c.""id_configuration"" AS ""IdConfiguration"",
                c.""parameter_name"" AS ""ParameterName"",
                c.""parameter_value"" AS ""ParameterValue""
            FROM ""Configuration"" c
            INNER JOIN (
                SELECT parameter_name, MAX(date) date
                FROM ""Configuration""
                GROUP BY parameter_name
            ) d
            ON c.parameter_name = d.parameter_name
            AND c.date = d.date
        ";
        return this._connection.Query<Configuration>(query);
    }

    public Configuration? GetById(int id)
    {
        const string query = @"
                SELECT
                    c.""id_configuration"" AS ""IdConfiguration"",
                    c.""parameter_name"" AS ""ParameterName"",
                    c.""parameter_value"" AS ""ParameterValue""
                FROM ""Configuration"" c
                INNER JOIN (
                    SELECT parameter_name, MAX(date) date
                    FROM ""Configuration""
                    GROUP BY parameter_name
                ) d
                ON c.parameter_name = d.parameter_name
                AND c.date = d.date
            ";
            return this._connection.QueryFirstOrDefault<Configuration>(query, new { IdConfiguration = id });
    }

    public int Create(Configuration configuration)
    {
        const string query = @"
                INSERT INTO ""Configuration"" (
                    ""parameter_name"",
                    ""parameter_value""
                )
                VALUES (
                    @ParameterName,
                    @ParameterValue
                )
                RETURNING ""id_configuration"" AS ""IdConfiguration"";
            ";
        int resultId = this._connection.QuerySingle<int>(query, new
        {
            ParameterName = configuration.ParameterName,
            ParameterValue = configuration.ParameterValue
        });

        return resultId;
    }
}
