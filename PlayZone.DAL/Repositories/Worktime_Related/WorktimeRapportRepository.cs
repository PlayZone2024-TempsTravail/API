using Dapper;
using Npgsql;
using PlayZone.DAL.Entities.Worktime_Related;
using PlayZone.DAL.Interfaces.Worktime_Related;

namespace PlayZone.DAL.Repositories.Worktime_Related;

public class WorktimeRapportRepository : IWorktimeRapportRepository
{
    private readonly NpgsqlConnection _connection;
    public WorktimeRapportRepository(NpgsqlConnection connection)
    {
        this._connection = connection;
    }

    public IEnumerable<WorktimeCompteurRapport> GetAll()
    {
        const string query = @"
            SELECT
                iduser,
                name,
                category,
                restant
            FROM v_get_all_counters;
        ";
        return this._connection.Query<WorktimeCompteurRapport>(query);
    }
}
