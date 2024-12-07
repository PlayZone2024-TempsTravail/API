using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using PlayZone.Razor.Services;
using PlayZone.Razor.Views;

namespace PlayZone.API.Controllers.Budget_Related;

[Route("api/[controller]")]
[ApiController]
public class PdfController : ControllerBase
{
    private readonly PdfGenerator _pdfGenerator;
    private readonly RazorViewRendererService _razorViewRendererService;

    public PdfController(RazorViewRendererService razorViewRendererService, PdfGenerator pdfGenerator)
    {
        this._razorViewRendererService = razorViewRendererService;
        this._pdfGenerator = pdfGenerator;
    }

    private FileContentResult Generate(object model, string view, string outputNameFile = "rapport")
    {
        string html = this._razorViewRendererService.RenderViewToStringAsync(view, model).Result;
        byte[] pdfBytes = this._pdfGenerator.Execute(html);
        return this.File(pdfBytes, "application/pdf", $"{outputNameFile}.pdf", true);
    }

    [HttpGet]
    public IActionResult GeneratePdf()
    {
        PdfTemplate model = new PdfTemplate();
        return this.Generate(model, "Views/PdfTemplate.cshtml");
    }

    [HttpGet("test")]
    public IActionResult GeneratePdfNatif()
    {
        MyView model = new MyView();
        return this.Generate(model, "Views/MyView.cshtml", "test_hello_world");
    }
}
