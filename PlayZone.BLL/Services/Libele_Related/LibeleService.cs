using PlayZone.BLL.Interfaces.Libele_Related;
using PlayZone.DAL.Interfaces.Libele_Related;
using PlayZone.BLL.Mappers.Libele_Related;
using PlayZone.BLL.Models.Libele_Related;

namespace PlayZone.BLL.Services.Libele_Related;

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

    public bool Update(Libele user)
    {
        return this._libeleRepository.Update(user.ToEntities());
    }

    public bool Delete(int idLibele)
    {
        return this._libeleRepository.Delete(idLibele);
    }
}
