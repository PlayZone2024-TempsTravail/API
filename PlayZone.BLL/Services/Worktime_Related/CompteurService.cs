using PlayZone.BLL.Interfaces.User_Related;
using PlayZone.BLL.Interfaces.Worktime_Related;
using PlayZone.BLL.Mappers.Worktime_Related;
using PlayZone.BLL.Models.User_Related;
using PlayZone.BLL.Models.Worktime_Related;
using PlayZone.DAL.Interfaces.Worktime_Related;

namespace PlayZone.BLL.Services.Worktime_Related;

public class CompteurService : ICompteurService
{
    private readonly ICompteurRepository _compteurRepository;
    public CompteurService(ICompteurRepository compteurRepository)
    {
        this._compteurRepository = compteurRepository;
    }

    public IEnumerable<CompteurAbsence> GetCounterOfAbsenceByUser(int idUser)
    {
        return this._compteurRepository.GetCounterOfAbsenceByUser(idUser).Select(c => c.ToModel());
    }

    public IEnumerable<CompteurProjet> GetCounterOfProjectByUser(int idUser)
    {
        return this._compteurRepository.GetCounterOfProjectByUser(idUser).Select(c => c.ToModel());
    }
}
