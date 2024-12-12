using System.Collections;
using Dapper;
using Npgsql;
using PlayZone.DAL.Interfaces.Worktime_Related;
using PlayZone.DAL.Entities.Worktime_Related;

namespace PlayZone.DAL.Repositories.Worktime_Related;

public class CompteurRepository : ICompteurRepository
{
    private readonly NpgsqlConnection _connection;
    public CompteurRepository(NpgsqlConnection connection)
    {
        this._connection = connection;
    }

    public IEnumerable<CompteurAbsence> GetCounterOfAbsenceByUser(int userId)
    {
        const string query = @"
            SELECT
                ""Category"",
                ""Max"",
                ""Utilise"" AS ""Counter"",
                ""Solde""
            FROM get_counters_for_user(@userId);
        ";
        return this._connection.Query<CompteurAbsence>(query, new { userId = userId});
    }

    public IEnumerable<CompteurProjet> GetCounterOfProjectByUser(int userId)
    {
        const string query = @"
            SELECT
                w.project_id AS projectId,
                p.name AS projectName,
                SUM(CEIL(EXTRACT(EPOCH FROM AGE(""end"", ""start"")) / 3600)) AS Heures
            FROM ""WorkTime"" w
            INNER JOIN ""Project"" p ON w.project_id = p.id_project
            WHERE ""project_id"" IS NOT NULL
            AND user_id = @userId
            AND EXTRACT(YEAR FROM ""start"") = EXTRACT(YEAR FROM NOW())
            GROUP BY projectId, projectName
            ORDER BY Heures DESC
        ";
        return this._connection.Query<CompteurProjet>(query, new { userId = userId});
    }
}
