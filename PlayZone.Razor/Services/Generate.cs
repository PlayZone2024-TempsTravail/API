using PlayZone.Razor.Interfaces;
using PlayZone.Razor.Views;
using Razor.Templating.Core;

namespace PlayZone.Razor.Services;

public class Generate : IGenerate
{
    public string WorktimeCounter()
    {
        if (!File.Exists("Views/PdfTemplate.cshtml"))
            throw new Exception("Le fichier template n'a pas été trouvé");

        PdfTemplate model = new PdfTemplate();
        return RazorTemplateEngine.RenderPartialAsync("~/Views/PdfTemplate.cshtml", model).Result;
    }
}
