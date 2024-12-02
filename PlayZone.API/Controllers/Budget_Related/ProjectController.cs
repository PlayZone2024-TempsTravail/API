using Microsoft.AspNetCore.Mvc;
using PlayZone.API.DTOs.Budget_Related;
using PlayZone.API.Mappers.Budget_Related;
using PlayZone.BLL.Interfaces.Budget_Related;
using PlayZone.BLL.Models.Budget_Related;


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

    [HttpGet("GetAll")]
    public IActionResult GetAll([FromQuery] string f = "all")
    {
        try
        {
            IEnumerable<ProjectDTO> projects = this._projectService.GetALL().Select(p => p.ToDTO());


            switch (f)
            {
                case "active":
                    return this.Ok(projects.Where(p => p.IsActive));
                case "inactive":
                    return this.Ok(projects.Where(p => !p.IsActive));
                default:
                    return this.Ok(projects);
            }
        }
        catch (Exception)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }


    [HttpGet("idproject/{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProjectDTO))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetByProjectId(int id)
    {
        try
        {
            ProjectDTO projects = this._projectService.GetById(id).ToDTO();
            return this.Ok(projects);
        }
        catch (Exception)
        {
            return this.NotFound("Project Not Found");
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

    [HttpPost("{id:int}")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProjectDTO))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Create([FromBody] ProjectCreateDTO project)
    {
        int resultId = this._projectService.Create(project.ToModel());
        if (resultId > 0)
        {
            ProjectDTO projects = this._projectService.GetById(resultId).ToDTO();
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
