using PlayZone.BLL.Interfaces.Budget_Related;
using PlayZone.BLL.Models.Budget_Related;
using PlayZone.BLL.Mappers.Budget_Related;
using PlayZone.BLL.Models.User_Related;
using PlayZone.DAL.Interfaces.Budget_Related;


namespace PlayZone.BLL.Services.Budget_Related;

public class DepenceService : IDepenseService
{
    private readonly IDepenseRepository _depenseRepository;

    public DepenceService(IDepenseRepository depenseRepository)
    {
        this._depenseRepository = depenseRepository;
    }

    public IEnumerable<Depense> GetByProjectId(int id)
    {
        return this._depenseRepository.GetByProjectId(id).Select(d => d.ToModel());
    }

    public Depense? GetById(int id)
    {
        return this._depenseRepository.GetById(id)?.ToModel();
    }

    public int Create(Depense depense)
    {
        return this._depenseRepository.Create(depense.ToEntity());
    }

    public bool Update(Depense depense)
    {
        return this._depenseRepository.Update(depense.ToEntity());
    }

    public bool Delete(int id)
    {
       return this._depenseRepository.Delete(id);
    }
}
