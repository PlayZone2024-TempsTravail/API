using Microsoft.AspNetCore.Mvc;
using PlayZone.BLL.Interfaces.Rapport_Related;

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

    [HttpGet("counter")]
    public IActionResult CounterRapport()
    {
        return this.File(
            this._rapportService.GetCounterRapport(),
            "application/pdf",
            "CounterRapport.pdf",
            true
        );
    }

    [HttpGet("times")]
    public IActionResult TimesRapport(DateTime start, DateTime end)
    {
        return this.File(
            this._rapportService.GetTimesRapport(start, end),
            "application/pdf",
            "TimesRapport.pdf",
            true
        );
    }
}
