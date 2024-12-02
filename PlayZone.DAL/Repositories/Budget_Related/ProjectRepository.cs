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
                p.""id_project"" AS ""IdProject"",
                p.""isActive"" AS ""IsActive"",
                p.""name"",
                p.""organisme_id"" AS ""OrganismeId"",
                o.""name"" AS ""OrganismeName"",
                p.""color"" AS ""Color"",
                p.""montant_budget"" AS ""MontantBudget"",
                p.""date_debut_projet"" AS ""DateDebutProjet"",
                p.""date_fin_projet"" AS ""DateFinProjet"",
                p.""charge_de_projet"" AS ""ChargeDeProjetId"",
                CONCAT_WS(' ', u.prenom, u.nom) AS ""ChargeDeProjetName"",
                prevision_depense.montant AS ""PrevisionDepenseActuelle"",
                depense.montant AS ""DepenseReelActuelle""
            FROM ""Project"" p
            INNER JOIN ""Organisme"" o ON p.organisme_id = o.id_organisme
            INNER JOIN ""User"" u ON p.charge_de_projet = u.id_user
            LEFT JOIN (
                SELECT project_id, SUM(montant) AS montant
                FROM (
                    SELECT project_id, montant, date
                    FROM ""Prevision_Budget_Category""
                    UNION ALL
                    SELECT project_id,montant, date
                    FROM ""Prevision_Budget_Libele""
                ) prevision_depense
                WHERE date <= NOW()
                GROUP BY project_id
            ) prevision_depense ON prevision_depense.project_id = p.id_project
            LEFT JOIN (
                SELECT project_id, SUM(montant) AS ""montant""
                FROM ""Depense""
                WHERE date_facturation <= NOW()
                GROUP BY project_id
            ) depense ON depense.project_id = p.id_project
            ORDER BY ""DateDebutProjet"" DESC;
        ";
        return this._connection.Query<Project>(query);
    }

    public IEnumerable<Project> GetByOrgaId(int id)
    {
        const string query = @"
            SELECT
                p.""id_project"" AS ""IdProject"",
                p.""isActive"" AS ""IsActive"",
                p.""name"",
                p.""organisme_id"" AS ""OrganismeId"",
                o.""name"" AS ""OrganismeName"",
                p.""color"" AS ""Color"",
                p.""montant_budget"" AS ""MontantBudget"",
                p.""date_debut_projet"" AS ""DateDebutProjet"",
                p.""date_fin_projet"" AS ""DateFinProjet"",
                p.""charge_de_projet"" AS ""ChargeDeProjetId"",
                CONCAT_WS(' ', u.prenom, u.nom) AS ""ChargeDeProjetName"",
                prevision_depense.montant AS ""PrevisionDepenseActuelle"",
                depense.montant AS ""DepenseReelActuelle""
            FROM ""Project"" p
            INNER JOIN ""Organisme"" o ON p.organisme_id = o.id_organisme
            INNER JOIN ""User"" u ON p.charge_de_projet = u.id_user
            LEFT JOIN (
                SELECT project_id, SUM(montant) AS montant
                FROM (
                    SELECT project_id, montant, date
                    FROM ""Prevision_Budget_Category""
                    UNION ALL
                    SELECT project_id,montant, date
                    FROM ""Prevision_Budget_Libele""
                ) prevision_depense
                WHERE date <= NOW()
                GROUP BY project_id
            ) prevision_depense ON prevision_depense.project_id = p.id_project
            LEFT JOIN (
                SELECT project_id, SUM(montant) AS ""montant""
                FROM ""Depense""
                WHERE date_facturation <= NOW()
                GROUP BY project_id
            ) depense ON depense.project_id = p.id_project
            WHERE p.""organisme_id"" = @OrganismeId
            ORDER BY ""DateDebutProjet"" DESC;
        ";
        return this._connection.Query<Project>(query, new { OrganismeId = id });
    }

    public Project? GetById(int id)
    {
        const string query = @"
            SELECT
                p.""id_project"" AS ""IdProject"",
                p.""isActive"" AS ""IsActive"",
                p.""name"",
                p.""organisme_id"" AS ""OrganismeId"",
                o.""name"" AS ""OrganismeName"",
                p.""color"" AS ""Color"",
                p.""montant_budget"" AS ""MontantBudget"",
                p.""date_debut_projet"" AS ""DateDebutProjet"",
                p.""date_fin_projet"" AS ""DateFinProjet"",
                p.""charge_de_projet"" AS ""ChargeDeProjetId"",
                CONCAT_WS(' ', u.prenom, u.nom) AS ""ChargeDeProjetName"",
                prevision_depense.montant AS ""PrevisionDepenseActuelle"",
                depense.montant AS ""DepenseReelActuelle""
            FROM ""Project"" p
            INNER JOIN ""Organisme"" o ON p.organisme_id = o.id_organisme
            INNER JOIN ""User"" u ON p.charge_de_projet = u.id_user
            LEFT JOIN (
                SELECT project_id, SUM(montant) AS montant
                FROM (
                    SELECT project_id, montant, date
                    FROM ""Prevision_Budget_Category""
                    UNION ALL
                    SELECT project_id,montant, date
                    FROM ""Prevision_Budget_Libele""
                ) prevision_depense
                WHERE date <= NOW()
                GROUP BY project_id
            ) prevision_depense ON prevision_depense.project_id = p.id_project
            LEFT JOIN (
                SELECT project_id, SUM(montant) AS ""montant""
                FROM ""Depense""
                WHERE date_facturation <= NOW()
                GROUP BY project_id
            ) depense ON depense.project_id = p.id_project
            WHERE p.""id_project"" = @IdProject
            ORDER BY ""DateDebutProjet"" DESC;
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
