using PlayZone.BLL.Models.Rapport_Related;
using PlayZone.Razor.Models;

namespace PlayZone.BLL.Mappers.Rapport_Related;

public static class WorktimeRapportMapper
{
    public static WorktimeRapportRazorModel ToRazor(this PreparedWorktimeRapport preparedWorktimeRapport)
    {
        return new WorktimeRapportRazorModel
        {
            Name = preparedWorktimeRapport.Name,
            Counters = new Dictionary<string, int>(preparedWorktimeRapport.Counters)
        };
    }
}
