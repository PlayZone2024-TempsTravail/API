using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayZone.API.Attributes;
using PlayZone.BLL.Interfaces.Rapport_Related;
using PlayZone.DAL.Entities.User_Related;

namespace PlayZone.API.Controllers.Rapport_Related;

[Route("api/[controller]")]
[ApiController]
public class RapportController : ControllerBase
{
    private readonly IRapportService _rapportService;

    public RapportController(IRapportService rapportService)
    {
        this._rapportService = rapportService;
    }

    [HttpGet("times")]
    [Authorize]
    [PermissionAuthorize(Permission.DEBUG_PERMISSION)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult TimesRapport(DateTime start, DateTime end)
    {
        return this.File(
            this._rapportService.GetTimesRapport(start, end),
            "application/pdf",
            "TimesRapport.pdf",
            true
        );
    }

    [HttpGet("counter")]
    [Authorize]
    [PermissionAuthorize(Permission.DEBUG_PERMISSION)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult CounterRapport()
    {
        return this.File(
            this._rapportService.GetCounterRapport(),
            "application/pdf",
            "CounterRapport.pdf",
            true
        );
    }
}
