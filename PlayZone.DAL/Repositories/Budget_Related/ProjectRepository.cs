using Dapper;
using Npgsql;
using PlayZone.DAL.Entities.Budget_Related;
using PlayZone.DAL.Interfaces.Budget_Related;

namespace PlayZone.DAL.Repositories.Budget_Related;

public class ProjectRepository : IProjectRepository
{
    private readonly NpgsqlConnection _connection;

    public ProjectRepository(NpgsqlConnection connection)
    {
        this._connection = connection;
    }

    public IEnumerable<Project> GetAll()
    {
        const string query = @"
            SELECT
                ""id_project"" AS ""IdProject"",
                ""name"",
                ""organisme_id"" AS ""OrganismeId"",
                ""color"" AS ""Color"",
                ""montant_budget"" AS ""MontantBudget"",
                ""date_debut_projet"" AS ""DateDebutProjet"",
                ""date_fin_projet"" AS ""DateFinProjet"",
                ""charge_de_projet"" AS ""ChargerDeProjetId"",
                ""isActive"" AS ""IsActive""
            FROM ""Project""
            ORDER BY ""DateDebutProjet"" DESC;
        ";
        return this._connection.Query<Project>(query);
    }

    public IEnumerable<Project> GetByOrgaId(int id)
    {
        const string query = @"
        SELECT
            ""id_project"" AS ""IdProject"",
            ""name"",
            ""organisme_id"" AS ""OrganismeId"",
            ""color"" AS ""Color"",
            ""montant_budget"" AS ""MontantBudget"",
            ""date_debut_projet"" AS ""DateDebutProjet"",
            ""date_fin_projet"" AS ""DateFinProjet"",
            ""charge_de_projet"" AS ""ChargerDeProjetId"",
            ""isActive"" AS ""IsActive""
        FROM ""Project""
        WHERE ""organisme_id"" = @OrganismeId
        ORDER BY ""DateDebutProjet"" DESC;
    ";
        return this._connection.Query<Project>(query, new { OrganismeId = id });
    }

    public Project? GetById(int id)
    {
        const string query = @"
         SELECT
            ""id_project"" AS ""IdProject"",
            ""name"",
            ""organisme_id"" AS ""OrganismeId"",
            ""color"" AS ""Color"",
            ""montant_budget"" AS ""MontantBudget"",
            ""date_debut_projet"" AS ""DateDebutProjet"",
            ""date_fin_projet"" AS ""DateFinProjet"",
            ""charge_de_projet"" AS ""ChargerDeProjetId"",
            ""isActive"" AS ""IsActive""
        FROM ""Project""
        WHERE ""id_project"" = @IdProject;
    ";
        return this._connection.QuerySingleOrDefault<Project>(query, new { IdProject = id });
    }
    public int Create(Project project)
    {
        const string query = @"
            INSERT INTO ""Project"" (""name"", ""montant_budget"",""organisme_id"",""color"", ""date_debut_projet"", ""date_fin_projet"", ""charge_de_projet"",""isActive"")
            VALUES (@Name, @MontantBudget,@OrganismeId,@Color, @DateDebutProjet, @DateFinProjet, @ChargerDeProjetId, @IsActive)
            RETURNING ""id_project"" AS ""IdProject"";
        ";
        return this._connection.QuerySingle<int>(query, new
        {
            Name = project.Name,
            OrganismeId = project.OrganismeId,
            Color = project.Color,
            MontantBudget = project.MontantBudget,
            DateDebutProjet = project.DateDebutProjet,
            DateFinProjet = project.DateFinProjet,
            ChargerDeProjetId = project.ChargerDeProjetId,
            IsActive = project.IsActive
        });
    }

    public bool Update(Project project)
    {
        const string query = @"
            UPDATE ""Project"" SET
                ""name"" = @Name,
                ""organisme_id"" = @OrganismeId,
                ""color"" = @Color,
                ""montant_budget"" = @MontantBudget,
                ""date_debut_projet"" = @DateDebutProjet,
                ""date_fin_projet"" = @DateFinProjet,
                ""charge_de_projet"" = @ChargerDeProjetId,
                ""isActive"" =  @IsActive
            WHERE ""id_project"" = @IdProject
        ";
        int affectedRows = this._connection.Execute(query, new
        {
            IdProject = project.IdProject,
            Name = project.Name,
            OrganismeId = project.OrganismeId,
            Color = project.Color,
            MontantBudget = project.MontantBudget,
            DateDebutProjet = project.DateDebutProjet,
            DateFinProjet = project.DateFinProjet,
            ChargerDeProjetId = project.ChargerDeProjetId,
            IsActive = project.IsActive
        });
        return affectedRows > 0;
    }
    public bool Delete(int id)
    {
        const string query = @"
            UPDATE ""Project"" SET
                    ""isActive"" = @IsActive
            WHERE ""id_project"" = @IdProject;
        ";
        int affectedRows = this._connection.Execute(query, new { IdProject = id });
        return affectedRows > 0;
    }
}
