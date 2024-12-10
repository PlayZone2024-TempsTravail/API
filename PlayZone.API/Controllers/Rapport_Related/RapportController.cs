using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayZone.API.Attributes;
using PlayZone.API.DTOs.Rapport_Related;
using PlayZone.API.Mappers.Rapport_Related;
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

    [HttpPost("project")]
    [Authorize]
    [PermissionAuthorize(Permission.DEBUG_PERMISSION)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult ProjectRapport(ProjectRapportDTO dto)
    {
        return this.File(
            this._rapportService.GetProjectRapport(dto.ToModel()),
            "application/pdf",
            "ProjectRapport.pdf",
            true
        );
    }

    // [HttpGet("times")]
    // [Authorize]
    // [PermissionAuthorize(Permission.DEBUG_PERMISSION)]
    // [ProducesResponseType(StatusCodes.Status200OK)]
    // public IActionResult TimesRapport(DateTime start, DateTime end)
    // {
    //     return this.File(
    //         this._rapportService.GetTimesRapport(start, end),
    //         "application/pdf",
    //         "TimesRapport.pdf",
    //         true
    //     );
    // }

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
