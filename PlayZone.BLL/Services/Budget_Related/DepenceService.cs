using PlayZone.BLL.Interfaces.Budget_Related;
using PlayZone.BLL.Models.Budget_Related;
using PlayZone.BLL.Mappers.Budget_Related;
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
        return this._depenseRepository.GetByProjectId(id).Select(d => new d.ToModel());
    }

    public Depense? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public int Create(Depense depense)
    {
        throw new NotImplementedException();
    }

    public bool Update(Depense depense)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }
}
