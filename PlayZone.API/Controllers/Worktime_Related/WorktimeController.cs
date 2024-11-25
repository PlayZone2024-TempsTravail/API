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

    [HttpPut("{id}")]
    [ProducesResponseType(statusCode: 200, type: typeof(Worktime))]
    [ProducesResponseType(statusCode: StatusCodes.Status500InternalServerError)]
    public IActionResult Update(int id, [FromBody] WorktimeUpdateFormDto worktime)
    {
        if (id <= 0)
        {
            return this.BadRequest("Invalid user data");
        }

        Worktime updatedWorktime = worktime.ToModels();
        updatedWorktime.IdWorktime = id;
        if (this._worktimeService.Update(updatedWorktime))
        {
            return this.Ok();
        }
        return this.StatusCode(StatusCodes.Status500InternalServerError);
    }
}
