using Models = PlayZone.BLL.Models.Worktime_Related;
using PlayZone.API.DTOs.Worktime_Related;

namespace PlayZone.API.Mappers.Worktime_Related;

public static class CompteurMapper
{
    public static CompteurAbsenceDTO ToDTO(this Models.CompteurAbsence compteur)
    {
        return new CompteurAbsenceDTO
        {
            Category = compteur.Category,
            Counter = compteur.Counter,
            Max = compteur.Max,
            Difference = compteur.Difference
        };
    }

    public static CompteurProjetDTO ToDTO(this Models.CompteurProjet compteur)
    {
        return new CompteurProjetDTO
        {
            projectId = compteur.projectId,
            projectName = compteur.projectName,
            Heures = compteur.Heures
        };
    }
}
