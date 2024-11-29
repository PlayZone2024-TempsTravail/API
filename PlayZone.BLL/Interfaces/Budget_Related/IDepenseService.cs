using PlayZone.BLL.Models.Budget_Related;

namespace PlayZone.BLL.Interfaces.Budget_Related;

public interface IDepenseService
{
    IEnumerable<Depense> GetByProjectId(int projectId);
    public Depense? GetById(int id);
    public int Create(Depense depense);
    public bool Update(Depense depense);
    public bool Delete(int id);
}
