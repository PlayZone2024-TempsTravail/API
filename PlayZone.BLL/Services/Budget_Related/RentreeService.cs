using System.Collections;
using PlayZone.BLL.Interfaces.Budget_Related;
using PlayZone.DAL.Interfaces.Budget_Related;
using PlayZone.BLL.Mappers.Budget_Related;
using PlayZone.BLL.Models.Budget_Related;

namespace PlayZone.BLL.Services.Budget_Related;

public class RentreeService : IRentreeService
{
    private readonly IRentreeRepository _rentreeRepository;
    public RentreeService(IRentreeRepository rentreeRepository)
    {
        this._rentreeRepository = rentreeRepository;
    }

    public IEnumerable<Rentree> GetAll()
    {
        return this._rentreeRepository.GetAll().Select(u => u.ToModel());
    }

    public IEnumerable<Rentree> GetByProject(int id)
    {
        return this._rentreeRepository.GetByProject(id).Select(u => u.ToModel());
    }


    public Rentree? GetById(int idRentree)
    {
        return this._rentreeRepository.GetById(idRentree)?.ToModel();
    }

    public int Create(Rentree rentree)
    {
        return this._rentreeRepository.Create(rentree.ToEntity());
    }

    public bool Update(Rentree rentree)
    {
        return this._rentreeRepository.Update(rentree.ToEntity());
    }

    public bool Delete(int id)
    {
        return this._rentreeRepository.Delete(id);
    }
}
