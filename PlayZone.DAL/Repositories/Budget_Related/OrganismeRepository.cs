using Dapper;
using Npgsql;
using PlayZone.DAL.Entities.Budget_Related;
using PlayZone.DAL.Interfaces.Budget_Related;

namespace PlayZone.DAL.Repositories.Budget_Related;

public class OrganismeRepository : IOrganismeRepository
{
    private readonly NpgsqlConnection _connection;

    public OrganismeRepository(NpgsqlConnection connection)
    {
        this._connection = connection;
    }

    public IEnumerable<Organisme> GetAll()
    {
        const string query = @"
            SELECT
                ""id_organisme"" AS ""IdOrganisme"",
                ""name"" AS ""Name""
            FROM ""Organisme"";
        ";
        return this._connection.Query<Organisme>(query);
    }

    // Requête SQL pour récupérer tous les enregistrements "Organisme"
    // 1. Mapper les colonnes de la table "Organisme" à la classe Organisme.
    // 2. Déterminer le type de chaque "Organisme" en fonction de l'existence de projets associés :
    //    - Si des projets associés existent, c'est un "Fournisseur".
    //    - Sinon, c'est un "Client".
    // 3. Trier les résultats pour afficher d'abord les Fournisseurs, puis les Clients, triés par ordre alphabétique sur le nom.
    public IEnumerable<Organisme> GetAllFournisseursFirst()
    {
        const string query = @"
        SELECT
            O.""id_organisme"" AS ""IdOrganisme"",
            O.""name"" AS ""Name"",
            CASE
                WHEN EXISTS (
                    SELECT 1
                    FROM ""Project"" P
                    WHERE P.""organisme_id"" = O.""id_organisme""
                ) THEN 'Fournisseur'
                ELSE 'Client'
            END AS ""type_organisme""
        FROM ""Organisme"" O
        ORDER BY
            CASE
                WHEN EXISTS (
                    SELECT 1
                    FROM ""Project"" P
                    WHERE P.""organisme_id"" = O.""id_organisme""
                ) THEN 1
                ELSE 2
            END,
            O.""name""
    ";
        return this._connection.Query<Organisme>(query);
    }

    // Requête SQL pour récupérer tous les enregistrements "Organisme"
    // 1. Mapper les colonnes de la table "Organisme" à la classe Organisme.
    // 2. Déterminer le type de chaque "Organisme" en fonction de l'existence de projets associés :
    //    - Si des projets associés existent, c'est un "Fournisseur".
    //    - Sinon, c'est un "Client".
    // 3. Trier les résultats pour afficher d'abord les Clients, puis les Fournisseurs, triés par ordre alphabétique sur le nom.
    public IEnumerable<Organisme> GetAllClientsFirst()
    {
        const string query = @"
        SELECT
            O.""id_organisme"" AS ""IdOrganisme"",
            O.""name"" AS ""Name"",
            CASE
                WHEN EXISTS (
                    SELECT 1
                    FROM ""Project"" P
                    WHERE P.""organisme_id"" = O.""id_organisme""
                ) THEN 'Fournisseur'
                ELSE 'Client'
            END AS ""type_organisme""
        FROM ""Organisme"" O
        ORDER BY
            CASE
                WHEN EXISTS (
                    SELECT 1
                    FROM ""Project"" P
                    WHERE P.""organisme_id"" = O.""id_organisme""
                ) THEN 2
                ELSE 1
            END,
            O.""name""
        ";
        return this._connection.Query<Organisme>(query);
    }

    public Organisme? GetById(int id)
    {
        const string query = @"
            SELECT
                ""id_organisme"" AS ""IdOrganisme"",
                ""name"" AS ""Name""
            FROM ""Organisme""
            WHERE ""id_organisme"" = @IdOrganisme;
        ";
        return this._connection.QuerySingleOrDefault<Organisme>(query, new { IdOrganisme = id });
    }

    public int Create(Organisme organisme)
    {
        const string query = @"
                INSERT INTO ""Organisme"" (
                    ""name""
                    )
                VALUES (
                    @Name
                    )
                RETURNING ""id_organisme""
        ";
        int resultId = this._connection.QuerySingle<int>(query, new
        {
            Name = organisme.Name
        });

        return resultId;
    }

    public bool Update(Organisme organisme)
    {
        const string query = @"
            UPDATE ""Organisme"" SET
                ""name"" = @Name
            WHERE ""id_organisme"" = @IdOrganisme
        ";
        int affectedRows = this._connection.Execute(query, new
        {
            IdOrganisme = organisme.IdOrganisme,
            Name = organisme.Name
        });
        return affectedRows > 0;
    }

    public bool Delete(int id)
    {
        const string query = @"DELETE FROM ""Organisme"" WHERE ""id_organisme"" = @IdOrganisme;";
        int affectedRows = this._connection.Execute(query, new { IdOrganisme = id });
        return affectedRows > 0;
    }
}
