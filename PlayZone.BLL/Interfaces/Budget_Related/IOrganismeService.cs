using PlayZone.BLL.Models.Budget_Related;

namespace PlayZone.BLL.Interfaces.Budget_Related;

public interface IOrganismeService
{
    public IEnumerable<Organisme> GetAll();
    public IEnumerable<Organisme> GetAllFournisseursFirst();
    public IEnumerable<Organisme> GetAllClientsFirst();
    public Organisme? GetById(int id);
    public int Create(Organisme organisme);
    public bool Update(Organisme organisme);
    public bool Delete(int id);
}
