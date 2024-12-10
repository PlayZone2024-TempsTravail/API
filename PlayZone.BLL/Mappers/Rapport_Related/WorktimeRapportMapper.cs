using PlayZone.BLL.Models.Rapport_Related;
using PlayZone.Razor.Models;
using CounterRapport = PlayZone.Razor.Models.CounterRapport;

namespace PlayZone.BLL.Mappers.Rapport_Related;

public static class WorktimeRapportMapper
{
    public static CounterRapport ToRazor(this Models.Rapport_Related.CounterRapport counterRapport)
    {
        return new CounterRapport
        {
            Name = counterRapport.Name,
            Counters = new Dictionary<string, int>(counterRapport.Counters)
        };
    }


}
