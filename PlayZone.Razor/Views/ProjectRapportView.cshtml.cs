using PlayZone.Razor.Models;

namespace PlayZone.Razor.Views;


public class ProjectRapportView
{
    public List<ProjectRapport> Rapports;

    public ProjectRapportView(IEnumerable<ExtractProjectRapport> rapports)
    {
        this.Rapports = new List<ProjectRapport>();

        foreach (ExtractProjectRapport epr in rapports)
        {
            ProjectRapport? project = this.Rapports.FirstOrDefault(r => r.Name == epr.ProjectName);

            if (project is null)
            {
                project = new ProjectRapport(epr.ProjectName);
                this.Rapports.Add(project);
            }

            ProjectRapport.Category? category = project.Categories.FirstOrDefault(c => c.Name == epr.CategoryName);

            if (category is null)
            {
                category = new ProjectRapport.Category(epr.CategoryName);
                project.Categories.Add(category);
            }

            ProjectRapport.Libelle? libelle = category.Libelles.FirstOrDefault(l => l.Name == epr.LibelleName);

            if (libelle is null)
            {
                libelle = new ProjectRapport.Libelle(epr.LibelleName);
                category.Libelles.Add(libelle);
            }

            libelle.InOuts.Add(new ProjectRapport.InOut(epr.Organisme, epr.Motif, epr.Date, epr.Montant));
        }
    }
}
