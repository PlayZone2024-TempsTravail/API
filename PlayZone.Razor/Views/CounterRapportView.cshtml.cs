using Microsoft.AspNetCore.Mvc.RazorPages;
using PlayZone.Razor.Models;

namespace PlayZone.Razor.Views;

public class CounterRapportView : PageModel
{
    public readonly IEnumerable<Models.CounterRapport> WorktimeRapports;
    public readonly List<string> Colonnes = new List<string>();

    public CounterRapportView(IEnumerable<Models.CounterRapport> worktimeRapports)
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
