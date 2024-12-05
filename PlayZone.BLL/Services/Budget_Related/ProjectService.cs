using PlayZone.BLL.Interfaces.Budget_Related;
using PlayZone.BLL.Mappers.Budget_Related;
using PlayZone.BLL.Models.Budget_Related;
using PlayZone.DAL.Entities.Budget_Related;
using PlayZone.DAL.Interfaces.Budget_Related;
using Project = PlayZone.BLL.Models.Budget_Related.Project;
using ProjectShort = PlayZone.BLL.Models.Budget_Related.ProjectShort;

namespace PlayZone.BLL.Services.Budget_Related;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;

    public ProjectService(IProjectRepository projectRepository)
    {
        this._projectRepository = projectRepository;
    }

    public IEnumerable<Project> GetALL()
    {
        return this._projectRepository.GetAll().Select(p => p.ToModel());
    }

    public IEnumerable<ProjectShort> GetAllShort()
    {
        return this._projectRepository.GetAllShort().Select(p => p.ToModel());
    }

    public IEnumerable<ProjectShort> GetAllShortOrderByWorktimeOfUser(int userId)
    {
        return this._projectRepository.GetAllShortOrderByWorktimeOfUser(userId).Select(p => p.ToModel());
    }

    public IEnumerable<Project> GetByOrgaId(int id)
    {
        return this._projectRepository.GetByOrgaId(id).Select(p => p.ToModel());
    }

    public Project? GetById(int id)
    {
        return this._projectRepository.GetById(id)?.ToModel();
    }

    public IEnumerable<PreparedCategory> GetMouvementsByProject(int idProjet)
    {
        List<PreparedCategory> preparedCategories = new List<PreparedCategory>();

        foreach (Mouvement mouvement in this._projectRepository.GetMouvementsByProject(idProjet))
        {
            PreparedCategory? preparedCategory = preparedCategories.FirstOrDefault(pc => pc.Name == mouvement.Category);

            if (preparedCategory == default)
            {
                preparedCategory = new PreparedCategory { Name = mouvement.Category };
                preparedCategories.Add(preparedCategory);
            }

            PreparedLibele? preparedLibele = preparedCategory.Libelles.FirstOrDefault(pl => pl.Name == mouvement.Libele);
            if (preparedLibele == default)
            {
                preparedLibele = new PreparedLibele { Name = mouvement.Libele };
                preparedCategory.Libelles.Add(preparedLibele);
            }

            preparedLibele.InOuts.Add(new PreparedInOut { Date = mouvement.Date, Montant = mouvement.Montant });
        }

        return preparedCategories;
    }

    public PreparedGraphic GetGraphiqueRentreeByProjet(int idProjet)
    {
        return this.PreparedGraphic(this._projectRepository.GetGraphiqueRentreeByProjet(idProjet));
    }

    public PreparedGraphic GetGraphiqueDepenseByProjet(int idProjet)
    {
        return this.PreparedGraphic(this._projectRepository.GetGraphiqueDepenseByProjet(idProjet));
    }

    private PreparedGraphic PreparedGraphic(IEnumerable<PrevisionGraphique> graphiqueByProjet)
    {
        PreparedGraphic pc = new PreparedGraphic();

        foreach (PrevisionGraphique pg in graphiqueByProjet)
        {
            pc.Date.Add(pg.Date);
            pc.Prevision.Add(pg.Prevision);
            pc.Reel.Add(pg.Reel);
        }

        return pc;
    }

    public int Create(Project project)
    {
        return this._projectRepository.Create(project.ToEntity());
    }

    public bool Update(Project project)
    {
        return this._projectRepository.Update(project.ToEntity());
    }

    public bool Delete(int Idproject)
    {
        return this._projectRepository.Delete(Idproject);
    }
}
