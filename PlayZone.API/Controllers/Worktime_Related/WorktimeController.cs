using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayZone.API.DTOs.Worktime_Related;
using PlayZone.API.Mappers.Worktime_Related;
using PlayZone.BLL.Interfaces.Worktime_Related;

namespace PlayZone.API.Controllers.Worktime_Related;

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
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                "An error occurred while retrieving worktimes.");
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
}
