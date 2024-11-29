using PlayZone.BLL.Interfaces.Budget_Related;
using PlayZone.BLL.Mappers.Budget_Related;
using PlayZone.BLL.Models.Budget_Related;
using PlayZone.DAL.Interfaces.Budget_Related;

namespace PlayZone.BLL.Services.Budget_Related;

public class PrevisionRentreeService : IPrevisionRentreeService
{
    private readonly IPrevisionRentreeRepository _previsionRentreeRepository;

    public PrevisionRentreeService(IPrevisionRentreeRepository previsionRentreeRepository)
    {
        _previsionRentreeRepository = previsionRentreeRepository;
    }

    public IEnumerable<PrevisionRentree> GetByProject(int projectId)
    {
        return this._previsionRentreeRepository.GetByProject(projectId).Select(pr => pr.ToModel());
    }

    public PrevisionRentree? GetById(int id)
    {
        return this._previsionRentreeRepository.GetById(id)?.ToModel();
    }

    public int Create(PrevisionRentree previsionRentree)
    {
        return this._previsionRentreeRepository.Create(previsionRentree.ToEntity());
    }

    public bool Update(PrevisionRentree previsionRentree)
    {
        return this._previsionRentreeRepository.Update(previsionRentree.ToEntity());
    }

    public bool Delete(int id)
    {
        return this._previsionRentreeRepository.Delete(id);
    }
}
