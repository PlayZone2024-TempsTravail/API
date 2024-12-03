using PlayZone.DAL.Entities.Worktime_Related;

namespace PlayZone.DAL.Interfaces.Worktime_Related;

public interface ICompteurRepository
{
    public IEnumerable<CompteurAbsence> GetCounterOfAbsenceByUser(int userId);
    public IEnumerable<CompteurProjet> GetCounterOfProjectByUser(int userId);
}
