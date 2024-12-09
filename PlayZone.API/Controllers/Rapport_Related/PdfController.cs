using Microsoft.AspNetCore.Mvc;
using PlayZone.BLL.Interfaces.Rapport_Related;
using PlayZone.Razor.Services;
using PlayZone.Razor.Views;

namespace PlayZone.API.Controllers.Rapport_Related;

[Route("api/[controller]")]
[ApiController]
public class PdfController : ControllerBase
{
    private readonly PdfGenerator _pdfGenerator;
    private readonly RazorViewRendererService _razorViewRendererService;
    private readonly IRapportService _rapportService;

    public PdfController(PdfGenerator pdfGenerator, RazorViewRendererService razorViewRendererService, IRapportService rapportService)
    {
        this._pdfGenerator = pdfGenerator;
        this._razorViewRendererService = razorViewRendererService;
        this._rapportService = rapportService;
    }

    [HttpGet]
    public IActionResult GeneratePdf()
    {
        return this.File(
            this._rapportService.GetWorktimeCounterRapport(),
            "application/pdf",
            "rapport.pdf",
            true
        );
    }

    [HttpGet("totalhours")]
    public IActionResult GenerateTotalHoursPdf(DateTime start, DateTime end)
    {
        return this.File(
            this._rapportService.GetWorktimeProjectRapport(start, end),
            "application/pdf",
            "rapport.pdf",
            true
        );
    }
}
