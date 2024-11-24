using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PlayZone.BLL.Interfaces.Worktime_Related;
using PlayZone.BLL.Models.Worktime_Related;
using PlayZone.API.DTOs.Worktime_Related;
using PlayZone.API.Mappers.Worktime_Related;

namespace PlayZone.API.Controllers.Worktime_Related;

public class WorktimeController : ControllerBase
{
    private readonly IWorktimeService _worktimeService;

    public WorktimeController(IWorktimeService worktimeServices)
    {
        this._worktimeService = worktimeServices;
    }

    [HttpGet]
    public IEnumerable<Worktime> GetAll()
    {
        return this._worktimeService.GeTAll();
    }

    public IActionResult Update(WorktimeDTO worktime)
    {
        try
        {
            this._worktimeService.Update(worktime.ToModel());
            return this.Ok();
        }
        catch (Exception)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}


