using Dapper;
using Microsoft.Extensions.Logging;
using Npgsql;
using PlayZone.DAL.Entities.Budget_Related;
using PlayZone.DAL.Interfaces.Budget_Related;


namespace PlayZone.DAL.Repositories.Budget_Related;

public class DepenseRepository : IDepenseRepository
{
    private readonly NpgsqlConnection _connection;

    public DepenseRepository(NpgsqlConnection connection)
    {
        this._connection = connection;
    }

    public IEnumerable<Depense> GetByProjectId(int id)
    {
        const string query = @"
            SELECT
                ""id_depense"" AS IdDepense,
                ""libele_id"" AS LibeleId,
                ""project_id"" AS ProjectId,
                ""organisme_id"" AS OrganismeId,
                ""montant"",
                ""date_intervention"" AS DateIntervention,
                ""date_facturation"" AS DateFacturation,
                ""motif""
            FROM ""Depense""
            WHERE ""project_id"" = @ProjectId
            ORDER BY ""date_intervention"" DESC;
            ";
        return this._connection.Query<Depense>(query, new { ProjectId = id });
    }

    public Depense? GetById(int id)
    {
        const string query = @"
            SELECT
                ""id_depense"" AS IdDepense,
                ""libele_id"" AS LibeleId,
                ""project_id"" AS ProjectId,
                ""organisme_id"" AS OrganismeId,
                ""montant"",
                ""date_intervention"" AS DateIntervention,
                ""date_facturation"" AS DateFacturation,
                ""motif""
            FROM ""Depense""
            WHERE ""id_depense"" = @IdDepense;
            ";
        return this._connection.QueryFirstOrDefault<Depense>(query, new { IdDepense = id });
    }

    public int Create(Depense depense)
    {
        const string query = @"
            INSERT INTO ""Depense"" (""libele_id"", ""project_id"", ""organisme_id"", ""montant"", ""date_intervention"", ""date_facturation"", ""motif"")
            VALUES (@LibeleId, @ProjectId, @OrganismeId, @Montant, @DateIntervention, @DateFacturation, @Motif)
            RETURNING ""id_depense"";
            ";
        return this._connection.QuerySingle<int>(query, depense);
    }

    public bool Update(Depense depense)
    {
        const string query = @"
            UPDATE ""Depense""
            SET
                ""libele_id"" = @LibeleId,
                ""project_id"" = @ProjectId,
                ""organisme_id"" = @OrganismeId,
                ""montant"" = @Montant,
                ""date_intervention"" = @DateIntervention,
                ""date_facturation"" = @DateFacturation,
                ""motif"" = @Motif
            WHERE ""id_depense"" = @IdDepense;
            ";
        int affectedRows =  this._connection.Execute(query, new
        {
            depense.IdDepense,
            depense.LibeleId,
            depense.ProjectId,
            OrganismeId = (depense.OrganismeId == 0) ? (int?)null : 0,
            depense.Montant,
            depense.DateIntervention,
            depense.DateFacturation,
            depense.Motif
        });
        return affectedRows > 0;;
    }

    public bool Delete(int id)
    {
        const string query = @"
            DELETE FROM ""Depense""
            WHERE ""id_depense"" = @IdDepense;
            ";
        return this._connection.Execute(query, new { IdDepense = id }) > 0;
    }
}
