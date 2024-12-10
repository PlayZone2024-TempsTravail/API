using Dapper;
using Npgsql;
using PlayZone.DAL.Entities.Rapport_Related;
using PlayZone.DAL.Interfaces.Rapport_Related;

namespace PlayZone.DAL.Repositories.Rapport_Related;

public class WorktimeRapportRepository : IWorktimeRapportRepository
{
    private readonly NpgsqlConnection _connection;
    public WorktimeRapportRepository(NpgsqlConnection connection)
    {
        this._connection = connection;
    }

    public IEnumerable<ExtractProjectRapport> GetProjectRapport(ProjectRapport pr)
    {
        const string query = @"
            SELECT
                ""projectId"",
                ""categoryId"",
                ""libelleId"",
                ""projectName"",
                ""categoryName"",
                ""libelleName"",
                ""organisme"",
                ""motif"",
                ""date"",
                ""montant""
            FROM get_all_inout_for_selected_projects(
                 TO_DATE(@startdate, 'YYYY-MM-DD'),
                 TO_DATE(@enddate, 'YYYY-MM-DD'),
                 @projects,
                 @libelles
            );
        ";
        return this._connection.Query<ExtractProjectRapport>(query, new
        {
            startdate = pr.DateStart.ToString("yyyy-MM-dd"),
            enddate = pr.DateEnd.ToString("yyyy-MM-dd"),
            projects = pr.Projects,
            libelles = pr.Libelles
        });
    }

    public IEnumerable<TimesProject> GetTimesRapport(DateTime start, DateTime end)
    {
        const string query = @"
            SELECT
                ""ProjectId"" AS ProjectId,
                ""ProjectName"" AS ProjectName,
                ""TotalDays"" AS TotalDays
            FROM get_TotalDays_By_Project(@start, @end);
        ";
        return this._connection.Query<TimesProject>(query, new { start = start, end = end });
    }

    public IEnumerable<CounterRapport> GetCounterRapport()
    {
        const string query = @"
            SELECT
                iduser AS IdUser,
                name AS Name,
                category AS Category,
                restant AS Count
            FROM v_get_all_counters;
        ";
        return this._connection.Query<CounterRapport>(query);
    }


}
