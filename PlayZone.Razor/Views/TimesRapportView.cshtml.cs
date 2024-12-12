using Microsoft.AspNetCore.Mvc.RazorPages;
using PlayZone.Razor.Models;

namespace PlayZone.Razor.Views;

public class TimesRapportView : PageModel
{
    public readonly IEnumerable<TimesRapport> DaysByProject;

    public TimesRapportView(IEnumerable<TimesRapport> daysByProject)
    {
        this.DaysByProject = daysByProject;
    }
}
