using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using PlayZone.API.Views;
using Razor.Templating.Core;

namespace PlayZone.API.Controllers.Budget_Related;

[Route("api/[controller]")]
[ApiController]
public class PdfController : ControllerBase
{
    private readonly IConverter _converter;

    public PdfController(IConverter converter)
    {
        this._converter = converter;
    }

    [HttpGet]
    public async Task<IActionResult> GeneratePdf()
    {
        // Ajouter une vérification pour s'assurer que le fichier existe
        if (!System.IO.File.Exists("Views/PdfTemplate.cshtml"))
        {
            return this.StatusCode(StatusCodes.Status404NotFound, $"Le fichier template n'a pas été trouvé");
        }

        PdfTemplate model = new PdfTemplate();
        string html = await RazorTemplateEngine.RenderAsync("Views/PdfTemplate.cshtml", model);

        GlobalSettings globalSettings = new GlobalSettings
        {
            ColorMode = ColorMode.Color,
            Orientation = Orientation.Portrait,
            PaperSize = PaperKind.A4,
            Margins = new MarginSettings { Top = 10, Bottom = 10, Left = 10, Right = 10 }
        };

        ObjectSettings objectSettings = new ObjectSettings
        {
            PagesCount = true,
            HtmlContent = html,
            WebSettings = { DefaultEncoding = "utf-8" },
            HeaderSettings = new HeaderSettings
            {
                FontName = "Arial",
                FontSize = 9,
                Line = true,
                Center = "Rapport Financier",
                Right = "[date] [time]",
                Spacing = 2.5
            },
            FooterSettings = new FooterSettings
            {
                FontName = "Arial",
                FontSize = 9,
                Line = true,
                Center = "[page] de [toPage]",
                Left = "Confidentiel",
                Right = "PlayZone2024",
                Spacing = 2.5
            }
        };

        HtmlToPdfDocument pdf = new HtmlToPdfDocument()
        {
            GlobalSettings = globalSettings,
            Objects = { objectSettings }
        };

        byte[] pdfBytes = this._converter.Convert(pdf);
        return File(pdfBytes, "application/pdf", "Rapport.pdf", true);
    }
}
