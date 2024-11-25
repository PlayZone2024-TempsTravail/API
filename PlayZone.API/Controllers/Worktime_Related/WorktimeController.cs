using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using PlayZone.API.DTOs.Worktime_Related;
using PlayZone.API.Mappers.Worktime_Related;
using PlayZone.BLL.Exceptions;
using PlayZone.BLL.Interfaces.Worktime_Related;
using PlayZone.BLL.Mappers.Worktime_Related;

namespace PlayZone.API.Controllers.Worktime_Related;

[Route("api/[controller]")]
[ApiController]
public class WorktimeController : ControllerBase
{
    private readonly IWorktimeService _worktimeService;

    public WorktimeController(IWorktimeService worktimeService)
    {
        this._worktimeService = worktimeService;
    }

    [HttpGet("id/{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetById(int id)
    {
        try
        {
            WorktimeDTO worktime = this._worktimeService.GetById(id).ToDTO();
            return this.Ok(worktime);
        }
        catch (Exception)
        {
            return this.NotFound("La plage horaire est introuvable.");
        }
    }

    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Create([FromBody] WorktimeCreateDTO worktime)
    {
        try
        {
            int resultId = this._worktimeService.Create(worktime.ToModels());
            if (resultId > 0)
            {
                return this.CreatedAtAction(nameof(this.GetById), new { id = resultId }, worktime);
            }
        }
        catch (WorktimeAlreadyExistException e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
        catch (Exception) { /* ignored */ }

        return this.StatusCode(StatusCodes.Status500InternalServerError);
    }
}
