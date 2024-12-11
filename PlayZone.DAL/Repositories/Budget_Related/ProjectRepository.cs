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
            SELECT *
            FROM ""v_getprojects"";
        ";
        return this._connection.Query<Project>(query);
    }

    public IEnumerable<ProjectShort> GetAllShort()
    {
        const string query = @"
            SELECT
                ""id_project"" AS IdProject,
                ""isActive"" AS IsActive,
                ""name""
            FROM ""Project"";
        ";
        return this._connection.Query<ProjectShort>(query);
    }

    public IEnumerable<ProjectShort> GetAllShortOrderByWorktimeOfUser(int idUser)
    {
        const string query = @"
            SELECT
                p.id_project AS IdProject,
                p.name AS Name,
                ""isActive"" AS IsActive,
                SUM(CEIL(EXTRACT(EPOCH FROM AGE(w.""end"", w.""start"")) / 3600)) AS Heures
            FROM ""Project"" p
            LEFT JOIN ""WorkTime"" w ON p.id_project = w.project_id
            GROUP BY p.name, id_project
            ORDER BY Heures DESC NULLS LAST;
                    ";
        return this._connection.Query<ProjectShort>(query);
    }

    public Project? GetById(int id)
    {
        const string query = @"
            SELECT *
            FROM ""v_getprojects""
            WHERE ""IdProject"" = @IdProject
        ";
        return this._connection.QuerySingleOrDefault<Project>(query, new { IdProject = id });
    }

    public IEnumerable<Project> GetByOrgaId(int id)
    {
        const string query = @"
            SELECT *
            FROM ""v_getprojects""
            WHERE ""OrganismeId"" = @OrganismeId;
        ";
        return this._connection.Query<Project>(query, new { OrganismeId = id });
    }

    public IEnumerable<Mouvement> GetMouvementsByProject(int idProject, bool useDepenses)
    {
        const string query = @"
            SELECT *
            FROM get_all_inout_for_project(@idProject, @useDepenses);
        ";
        return this._connection.Query<Mouvement>(query, new { idProject = idProject, useDepenses = useDepenses});
    }

    public IEnumerable<PrevisionGraphique> GetGraphiqueRentreeByProjet(int idProjet)
    {
        const string query = @"
            SELECT
                ""month_year"" ""date"",
                ""cumulative_montant_prevision"" ""prevision"",
                ""cumulative_montant_reel"" ""reel""
            FROM get_cumulative_rentree(@idProject);
        ";
        return this._connection.Query<PrevisionGraphique>(query, new { idProject = idProjet });
    }

    public IEnumerable<PrevisionGraphique> GetGraphiqueDepenseByProjet(int idProjet)
    {
        const string query = @"
            SELECT
                ""month_year"" ""date"",
                ""cumulative_montant_prevision"" ""prevision"",
                ""cumulative_montant_reel"" ""reel""
            FROM get_cumulative_depense(@idProject);
        ";
        return this._connection.Query<PrevisionGraphique>(query, new { idProject = idProjet });
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
            ChargerDeProjetId = project.ChargeDeProjetId,
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
            ChargerDeProjetId = project.ChargeDeProjetId,
            IsActive = project.IsActive
        });
        return affectedRows > 0;
    }

    public bool Delete(int id)
    {
        const string query = @"
            UPDATE ""Project"" SET
                    ""isActive"" = false
            WHERE ""id_project"" = @IdProject;
        ";
        int affectedRows = this._connection.Execute(query, new { IdProject = id });
        return affectedRows > 0;
    }
}
