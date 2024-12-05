using Microsoft.AspNetCore.Mvc;
using PlayZone.API.Attributes;
using PlayZone.API.DTOs.Budget_Related;
using PlayZone.API.Mappers.Budget_Related;
using PlayZone.BLL.Interfaces.Budget_Related;
using PlayZone.BLL.Models.Budget_Related;
using PlayZone.DAL.Entities.User_Related;


namespace PlayZone.API.Controllers.Budget_Related;

[Route("api/[controller]")]
[ApiController]
public class ProjectController : ControllerBase
{
    private readonly IProjectService _projectService;

    public ProjectController(IProjectService projectService)
    {
        this._projectService = projectService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        try
        {
            IEnumerable<ProjectDTO> projects = this._projectService.GetALL().Select(p => p.ToDTO());
            return this.Ok(projects);
        }
        catch (Exception)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("short")]
    public IActionResult GetAllShort()
    {
        try
        {
            IEnumerable<ProjectShortDTO> projects = this._projectService.GetAllShort().Select(p => p.ToDTO());
            return this.Ok(projects);
        }
        catch (Exception) { /* Ignored */ }
        return this.StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpGet("short/{idUser:int}")]
    public IActionResult GetAllShort(int idUser)
    {
        try
        {
            IEnumerable<ProjectShortDTO> projects = this._projectService.GetAllShortOrderByWorktimeOfUser(idUser).Select(p => p.ToDTO());
            return this.Ok(projects);
        }
        catch (Exception) { /* Ignored */ }
        return this.StatusCode(StatusCodes.Status500InternalServerError);
    }


    [HttpGet("data/{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetInputOuputByProject(int id)
    {
        return this.Ok(this._projectService.GetMouvementsByProject(id));
    }


    [HttpGet("idproject/{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProjectDTO))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetByProjectId(int id)
    {
        try
        {
            ProjectDTO? projects = this._projectService.GetById(id)?.ToDTO();
            if (projects == null)
            {
                return this.NotFound("Project Not Found");
            }
            return this.Ok(projects);
        }
        catch (Exception)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError);
        }

    }

    [HttpGet("idorganisme/{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProjectDTO))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetByOrgaId(int id)
    {
        try
        {
            IEnumerable<ProjectDTO> projects = this._projectService.GetByOrgaId(id).Select(p => p.ToDTO());
            return this.Ok(projects);
        }
        catch (Exception)
        {
            return this.NotFound("Project Not Found");
        }
    }

    [HttpGet("graphique/rentree/{idProject:int}")]
    [PermissionAuthorize(Permission.DEBUG_PERMISSION)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PreparedGraphicDTO))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetGraphiqueRentreeByProjet(int idProject)
    {
        try
        {
            PreparedGraphicDTO pg = this._projectService.GetGraphiqueRentreeByProjet(idProject).ToDTO();
            return this.Ok(pg);
        }
        catch (Exception)
        { /* Ignored */ }
        return this.StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpGet("graphique/depense/{idProject:int}")]
    [PermissionAuthorize(Permission.DEBUG_PERMISSION)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PreparedGraphicDTO))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetGraphiqueDepenseByProjet(int idProject)
    {
        try
        {
            PreparedGraphicDTO pg = this._projectService.GetGraphiqueDepenseByProjet(idProject).ToDTO();
            return this.Ok(pg);
        }
        catch (Exception)
        { /* Ignored */ }
        return this.StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpPost("{id:int}")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProjectDTO))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Create([FromBody] ProjectCreateDTO project)
    {
        int resultId = this._projectService.Create(project.ToModel());
        if (resultId > 0)
        {
            ProjectDTO projects = this._projectService.GetById(resultId)!.ToDTO();
            return this.CreatedAtAction(nameof(this.GetByProjectId), new { id = resultId }, projects);
        }

        return this.StatusCode(StatusCodes.Status500InternalServerError, resultId);
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Update(int id, [FromBody] ProjectUpdateDTO project)
    {
        if (id <= 0)
        {
            return this.NotFound("Project Not Found");
        }

        Project updateProject = project.ToModel();
        updateProject.IdProject = id;
        if (this._projectService.Update(updateProject))
        {
            return this.Ok();
        }

        return this.StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Delete(int id)
    {
        if (id <= 0)
        {
            return this.NotFound("Project Not Found");
        }

        if (this._projectService.Delete(id))
        {
            return this.Ok();
        }

        return this.StatusCode(StatusCodes.Status500InternalServerError);
    }
}
