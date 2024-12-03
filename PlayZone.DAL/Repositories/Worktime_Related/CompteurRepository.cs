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
                used.abreviation as Category,
                used.count as Counter,
                max.max as Max,
                COALESCE(max.max-used.count, null) as Difference
            FROM (
                SELECT DISTINCT wc.""id_workTime_category"", wc.""abreviation"", COALESCE(SUM(""hours""), 0) AS count
                FROM (
                    SELECT ""id_WorkTime"", ""category_id"", ""project_id"", ""user_id"", CEIL(EXTRACT(EPOCH FROM AGE(""end"", ""start"")) / 3600) AS hours
                    FROM ""WorkTime"" w
                    WHERE EXTRACT(YEAR FROM start) = EXTRACT(YEAR FROM NOW())
                    AND user_id = @userId
                ) wr
                RIGHT JOIN ""WorkTime_Category"" wc ON ""wr"".category_id = wc.""id_workTime_category""
                GROUP BY wc.""id_workTime_category"", wc.""abreviation""
                ORDER BY wc.""id_workTime_category""
            ) used
            FULL JOIN (
                SELECT ""user_id"", ""workTime_category_id"" AS category_id, ""quantity"" AS max
                FROM ""Compteur_WorkTime_Category""
                WHERE user_id = @userId
            ) max ON used.""id_workTime_category"" = max.category_id
            WHERE abreviation <> 'VIEC';
        ";
        return this._connection.Query<CompteurAbsence>(query, new { userId = userId});
    }

    public IEnumerable<CompteurProjet> GetCounterOfProjectByUser(int userId)
    {
        const string query = @"
            SELECT
                w.project_id AS projectId,
                p.name AS projectName,
                CEIL(EXTRACT(EPOCH FROM AGE(""end"", ""start"")) / 3600) AS Heures
            FROM ""WorkTime"" w
            INNER JOIN ""Project"" p ON w.project_id = p.id_project
            WHERE ""project_id"" IS NOT NULL
            AND user_id = @userId
            AND EXTRACT(YEAR FROM ""start"") = EXTRACT(YEAR FROM NOW())
            ORDER BY Heures DESC;
        ";
        return this._connection.Query<CompteurProjet>(query, new { userId = userId});
    }
}
