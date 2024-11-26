using PlayZone.BLL.Interfaces.Budget_Related;
using PlayZone.BLL.Mappers.Budget_Related;
using PlayZone.BLL.Models.Budget_Related;
using PlayZone.DAL.Interfaces.Budget_Related;

namespace PlayZone.BLL.Services.Budget_Related;

public class LibeleService : ILibeleService
{
    private readonly ILibeleRepository _libeleRepository;
    public LibeleService(ILibeleRepository libeleRepository)
    {
        this._libeleRepository = libeleRepository;
    }

    public IEnumerable<Libele> GetAll()
    {
        return this._libeleRepository.GetAll().Select(u => u.ToModels());
    }

    public Libele? GetById(int id)
    {
        return this._libeleRepository.GetById(id)?.ToModels();
    }

    public int Create(Libele libele)
    {
        return this._libeleRepository.Create(libele.ToEntities());
    }

    public bool Update(Libele libele)
    {
        return this._libeleRepository.Update(libele.ToEntities());
    }

    public bool Delete(int idLibele)
    {
        return this._libeleRepository.Delete(idLibele);
    }
}
