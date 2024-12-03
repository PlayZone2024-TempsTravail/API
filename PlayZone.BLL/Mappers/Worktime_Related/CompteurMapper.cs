using PlayZone.BLL.Models.Worktime_Related;
using Entities = PlayZone.DAL.Entities.Worktime_Related;

namespace PlayZone.BLL.Mappers.Worktime_Related;

public static class CompteurMapper
{
    public static CompteurAbsence ToModel(this Entities.CompteurAbsence entity)
    {
        return new CompteurAbsence
        {
            Category = entity.Category,
            Counter = entity.Counter,
            Max = entity.Max,
            Difference = entity.Difference
        };
    }

    public static CompteurProjet ToModel(this Entities.CompteurProjet entity)
    {
        return new CompteurProjet
        {
            projectId = entity.projectId,
            projectName = entity.projectName,
            Heures = entity.Heures
        };
    }
}
