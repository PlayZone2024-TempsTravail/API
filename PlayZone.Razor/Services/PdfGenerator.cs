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

    public byte[] Execute(string html)
    {
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

        return this._converter.Convert(pdf);
    }
}
