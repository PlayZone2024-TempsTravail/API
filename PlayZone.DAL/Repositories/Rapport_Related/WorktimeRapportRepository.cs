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
    public IEnumerable<WorktimeRapport> GetAll()
    {
        const string query = @"
            SELECT
                iduser AS IdUser,
                name AS Name,
                category AS Category,
                restant AS Count
            FROM v_get_all_counters;
        ";
        return this._connection.Query<WorktimeRapport>(query);
    }
}
