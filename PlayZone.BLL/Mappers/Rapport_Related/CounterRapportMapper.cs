using CounerRapportModel = PlayZone.BLL.Models.Rapport_Related.CounterRapport;
using CounterRapportRazor = PlayZone.Razor.Models.CounterRapport;

namespace PlayZone.BLL.Mappers.Rapport_Related;

public static class CounterRapportMapper
{
    public static CounterRapportRazor ToRazor(this CounerRapportModel counterRapport)
    {
        return new CounterRapportRazor
        {
            Name = counterRapport.Name,
            Counters = new Dictionary<string, int>(counterRapport.Counters)
        };
    }
}
