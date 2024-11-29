using PlayZone.DAL.Entities.Budget_Related;

namespace PlayZone.DAL.Interfaces.Budget_Related;

public interface IOrganismeRepository
{
    public IEnumerable<Organisme> GetAll();
    public IEnumerable<Organisme> GetAllFournisseursFirst();
    public IEnumerable<Organisme> GetAllClientsFirst();
    public Organisme? GetById(int id);
    public int Create(Organisme organisme);
    public bool Update(Organisme organisme);
    public bool Delete(int id);
}
