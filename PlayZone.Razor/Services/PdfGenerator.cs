using DinkToPdf;
using DinkToPdf.Contracts;

namespace PlayZone.Razor.Services;

public class PdfGenerator
{
    private readonly IConverter _converter;
    public PdfGenerator(IConverter converter)
    {
        this._converter = converter;
    }

    public byte[] Execute(string html, string? title = null, Orientation orientation = Orientation.Portrait)
    {
        GlobalSettings globalSettings = new GlobalSettings
        {
            ColorMode = ColorMode.Color,
            Orientation = orientation,
            PaperSize = PaperKind.A4,
            Margins = new MarginSettings { Top = 10, Bottom = 10, Left = 10, Right = 10 }
        };

        ObjectSettings objectSettings = new ObjectSettings
        {
            PagesCount = true,
            HtmlContent = html,
            WebSettings = { DefaultEncoding = "utf-8" },
            FooterSettings = new FooterSettings
            {
                FontName = "Arial",
                FontSize = 9,
                Line = true,
                Center = "[page] de [toPage]",
                Left = "[date]",
                Right = "Institut Eco-Conseil",
                Spacing = 2.5
            }
        };
        if (title is not null)
        {
            objectSettings.HeaderSettings = new HeaderSettings
            {
                FontName = "Arial",
                FontSize = 9,
                Line = true,
                Center = title,
                Spacing = 2.5
            };
        }

        HtmlToPdfDocument pdf = new HtmlToPdfDocument()
        {
            GlobalSettings = globalSettings,
            Objects = { objectSettings }
        };

        return this._converter.Convert(pdf);
    }
}
