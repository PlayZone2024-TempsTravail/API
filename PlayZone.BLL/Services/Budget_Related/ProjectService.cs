using PlayZone.BLL.Interfaces.Budget_Related;
using PlayZone.BLL.Mappers.Budget_Related;
using PlayZone.BLL.Models.Budget_Related;
using PlayZone.DAL.Interfaces.Budget_Related;

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

    public IEnumerable<Project> GetByOrgaId(int id)
    {
        return this._projectRepository.GetByOrgaId(id).Select(p => p.ToModel());
    }

    public Project? GetById(int id)
    {
        return this._projectRepository.GetById(id)?.ToModel();
    }

    public int Create(Project project)
    {
        return this._projectRepository.Create(project.ToEntity());
    }

    public bool Update(Project project)
    {
        return this._projectRepository.Update(project.ToEntity());
    }
}
