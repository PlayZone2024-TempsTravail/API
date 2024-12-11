using PlayZone.BLL.Models.Worktime_Related;

namespace PlayZone.BLL.Interfaces.Worktime_Related;

public interface ICompteurService
{
    public IEnumerable<CompteurAbsence> GetCounterOfAbsenceByUser(int idUser);
    public IEnumerable<CompteurProjet> GetCounterOfProjectByUser(int idUser);
}
