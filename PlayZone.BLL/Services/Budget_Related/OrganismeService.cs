using PlayZone.BLL.Interfaces.Budget_Related;
using PlayZone.BLL.Mappers.Budget_Related;
using PlayZone.BLL.Models.Budget_Related;
using PlayZone.DAL.Interfaces.Budget_Related;

namespace PlayZone.BLL.Services.Budget_Related;

public class OrganismeService : IOrganismeService
{
    private readonly IOrganismeRepository _organismeRepository;

    public OrganismeService(IOrganismeRepository organismeRepository)
    {
        this._organismeRepository = organismeRepository;
    }

    public IEnumerable<Organisme> GetAll()
    {
        return this._organismeRepository.GetAll().Select(o => o.ToModels());
    }

    public IEnumerable<Organisme> GetAllFournisseursFirst()
    {
        return this._organismeRepository.GetAllFournisseursFirst().Select(o => o.ToModels());
    }

    public IEnumerable<Organisme> GetAllClientsFirst()
    {
        return this._organismeRepository.GetAllClientsFirst().Select(o => o.ToModels());
    }

    public Organisme? GetById(int id)
    {
        return this._organismeRepository.GetById(id)?.ToModels();
    }

    public int Create(Organisme organisme)
    {
        return this._organismeRepository.Create(organisme.ToEntities());
    }

    public bool Update(Organisme organisme)
    {
        return this._organismeRepository.Update(organisme.ToEntities());
    }

    public bool Delete(int id)
    {
        return this._organismeRepository.Delete(id);
    }
}
