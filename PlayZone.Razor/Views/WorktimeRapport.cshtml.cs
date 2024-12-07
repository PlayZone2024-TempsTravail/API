using Microsoft.AspNetCore.Mvc.RazorPages;
using PlayZone.Razor.Models;

namespace PlayZone.Razor.Views;

public class WorktimeRapport : PageModel
{
    public readonly IEnumerable<WorktimeRapportRazorModel> WorktimeRapports;
    public readonly List<string> Colonnes = new List<string>();

    public WorktimeRapport(IEnumerable<WorktimeRapportRazorModel> worktimeRapports)
    {
        this.WorktimeRapports = worktimeRapports;
        this.Colonnes = new List<string>();

        if (this.WorktimeRapports.Any())
        {
            this.Colonnes.Add("Prenom Nom");
            var firstWorktimeRapport = this.WorktimeRapports.FirstOrDefault().Counters;

            if (firstWorktimeRapport is not null)
            {
                foreach (string key in firstWorktimeRapport.Keys) this.Colonnes.Add(key);
            }
        }
    }
}
