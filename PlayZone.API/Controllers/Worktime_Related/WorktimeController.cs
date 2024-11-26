using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using PlayZone.API.DTOs.Worktime_Related;
using PlayZone.API.Mappers.Worktime_Related;
using PlayZone.BLL.Exceptions;
using PlayZone.BLL.Interfaces.Worktime_Related;
using Models = PlayZone.BLL.Models.Worktime_Related;
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

    [HttpGet("range")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<WorktimeDTO>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetByDateRange([FromQuery] int userId, [FromQuery] DateTime startDate,
        [FromQuery] DateTime endDate)
    {
        try
        {
            IEnumerable<WorktimeDTO> worktimes = this._worktimeService
                .GetByDateRange(userId, startDate, endDate)
                .Select(w => w.ToDTO());
            return this.Ok(worktimes);
        }
        catch (Exception)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("day/{userId:int}/{dayOfMonth:int}/{monthOfYear:int}/{year:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<WorktimeDTO>))]
    public IActionResult GetByDay(int userId, int dayOfMonth, int monthOfYear, int year)
    {
        try
        {
            IEnumerable<WorktimeDTO> worktimes = this._worktimeService
                .GetByDay(userId, dayOfMonth, monthOfYear, year)
                .Select(w => w.ToDTO());
            return this.Ok(worktimes);
        }
        catch (Exception)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("week/{userId:int}/{weekOfYear:int}/{year:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<WorktimeDTO>))]
    public IActionResult GetByWeek(int userId, int weekOfYear, int year)
    {
        try
        {
            IEnumerable<WorktimeDTO> worktimes = this._worktimeService
                .GetByWeek(userId, weekOfYear, year)
                .Select(w => w.ToDTO());
            return this.Ok(worktimes);
        }
        catch (Exception)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("month/{userId:int}/{monthOfYear:int}/{year:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<WorktimeDTO>))]
    public IActionResult GetByMonth(int userId, int monthOfYear, int year)
    {
        try
        {
            IEnumerable<WorktimeDTO> worktimes = this._worktimeService
                .GetByMonth(userId, monthOfYear, year)
                .Select(w => w.ToDTO());
            return this.Ok(worktimes);
        }
        catch (Exception)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Update(int id, [FromBody] WorktimeUpdateFormDto worktime)
    {
        if (id <= 0)
        {
            return this.BadRequest("Invalid user data");
        }

        Models.Worktime updatedWorktime = worktime.ToModels();
        updatedWorktime.IdWorktime = id;
        if (this._worktimeService.Update(updatedWorktime))
        {
            return this.Ok();
        }
        return this.StatusCode(StatusCodes.Status500InternalServerError);
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
