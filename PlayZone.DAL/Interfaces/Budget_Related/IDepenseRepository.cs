using PlayZone.DAL.Entities.Budget_Related;

namespace PlayZone.DAL.Interfaces.Budget_Related;

public interface IDepenseRepository
{
    IEnumerable<Depense> GetByProjectId(int projectId);
    public Depense? GetById(int id);
    public int Create(Depense depense);
    public bool Update(Depense depense);
    public bool Delete(int id);
}
