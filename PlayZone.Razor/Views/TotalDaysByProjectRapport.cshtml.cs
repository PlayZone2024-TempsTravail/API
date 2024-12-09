using Microsoft.AspNetCore.Mvc.RazorPages;
using PlayZone.Razor.Models;

namespace PlayZone.Razor.Views;

public class TotalDaysByProjectRapport : PageModel
{
    public readonly IEnumerable<TotalDaysByProjectModel> DaysByProject;

    public TotalDaysByProjectRapport(IEnumerable<TotalDaysByProjectModel> daysByProject)
    {
        this.DaysByProject = daysByProject;
    }
}
