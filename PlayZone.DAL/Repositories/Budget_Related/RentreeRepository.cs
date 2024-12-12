using Dapper;
using Npgsql;
using PlayZone.DAL.Entities.Budget_Related;
using PlayZone.DAL.Interfaces.Budget_Related;

namespace PlayZone.DAL.Repositories.Budget_Related;

public class RentreeRepository : IRentreeRepository
{
    private readonly NpgsqlConnection _connection;

    public RentreeRepository(NpgsqlConnection connection)
    {
        this._connection = connection;
    }

    public IEnumerable<Rentree> GetAll()
    {
        const string query = @"
            SELECT
                ""id_rentree"" AS ""IdRentree"",
                ""libele_id"" AS ""IdLibele"",
                ""project_id"" AS ""IdProject"",
                ""organisme_id"" AS ""IdOrganisme"",
                ""montant"" AS ""Montant"",
                ""date_facturation"" AS ""DateFacturation"",
                ""motif"" AS ""Motif""
            FROM ""Rentree"";
        ";
        return this._connection.Query<Rentree>(query);
    }

    public IEnumerable<Rentree> GetByProject(int id)
    {
        const string query = @"
            SELECT
                ""id_rentree"" AS ""IdRentree"",
                ""libele_id"" AS ""IdLibele"",
                ""project_id"" AS ""IdProject"",
                ""organisme_id"" AS ""IdOrganisme"",
                ""montant"" AS ""Montant"",
                ""date_facturation"" AS ""DateFacturation"",
                ""motif"" AS ""Motif""
            FROM ""Rentree""
            WHERE ""project_id"" = @IdProject;
        ";
        return this._connection.Query<Rentree>(query, new { IdProject = id });
    }

    public Rentree? GetById(int id)
    {
        const string query = @"
            SELECT
                ""id_rentree"" AS ""IdRentree"",
                ""libele_id"" AS ""IdLibele"",
                ""project_id"" AS ""IdProject"",
                ""organisme_id"" AS ""IdOrganisme"",
                ""montant"" AS ""Montant"",
                ""date_facturation"" AS ""DateFacturation"",
                ""motif"" AS ""Motif""
            FROM ""Rentree""
            WHERE ""id_rentree"" = @IdRentree;
        ";
        return this._connection.QuerySingleOrDefault<Rentree>(query, new { IdRentree = id });
    }

    public int Create(Rentree rentree)
    {
        const string query = @"
                INSERT INTO ""Rentree"" (
                    ""libele_id"",
                    ""project_id"",
                    ""organisme_id"",
                    ""montant"",
                    ""date_facturation"",
                    ""motif""
                    )
                VALUES (
                    @IdLibele,
                    @IdProject,
                    @IdOrganisme,
                    @Montant,
                    @DateFacturation,
                    @Motif
                    )
                RETURNING ""id_rentree"" AS ""IdRentree""
        ";
        int resultId = this._connection.QuerySingle<int>(query, new
        {
            IdLibele = rentree.IdLibele,
            IdProject = rentree.IdProject,
            IdOrganisme = rentree.IdOrganisme,
            Montant = rentree.Montant,
            DateFacturation = rentree.DateFacturation,
            Motif = rentree.Motif

        });

        return resultId;
    }

    public bool Update(Rentree rentree)
    {
        const string query = @"
            UPDATE ""Rentree"" SET
                ""libele_id"" = @IdLibele,
                ""project_id"" = @IdProject,
                ""organisme_id"" = @IdOrganisme,
                ""montant"" = @Montant,
                ""date_facturation"" = @DateFacturation,
                ""motif"" = @Motif

            WHERE ""id_rentree"" = @IdRentree
        ";
        int affectedRows = this._connection.Execute(query, new
        {
            IdRentree = rentree.IdRentree,
            IdLibele = rentree.IdLibele,
            IdProject = rentree.IdProject,
            IdOrganisme = rentree.IdOrganisme,
            Montant = rentree.Montant,
            DateFacturation = rentree.DateFacturation,
            Motif = rentree.Motif
        });
        return affectedRows > 0;
    }

    public bool Delete(int id)
    {
        const string query = @"DELETE FROM ""Rentree"" WHERE ""id_rentree"" = @IdRentree;";
        int affectedRows = this._connection.Execute(query, new { IdRentree = id });
        return affectedRows > 0;
    }
}



