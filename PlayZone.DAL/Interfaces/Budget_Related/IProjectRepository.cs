using PlayZone.DAL.Entities.Budget_Related;

namespace PlayZone.DAL.Interfaces.Budget_Related;

public interface IProjectRepository
{
    public IEnumerable<Project> GetAll();
    public IEnumerable<ProjectShort> GetAllShort();
    public IEnumerable<ProjectShort> GetAllShortOrderByWorktimeOfUser(int idUser);
    public IEnumerable<Project> GetByOrgaId(int id);
    public Project? GetById(int id);
    public IEnumerable<Mouvement> GetMouvementsByProject(int idProject, bool useDepenses);
    public IEnumerable<PrevisionGraphique> GetGraphiqueRentreeByProjet(int idProjet);
    public IEnumerable<PrevisionGraphique> GetGraphiqueDepenseByProjet(int idProjet);
    public int Create(Project project);
    public bool Update(Project project);
    public bool Delete(int id);
}
