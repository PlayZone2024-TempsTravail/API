using DinkToPdf;
using Microsoft.Extensions.Logging;
using PlayZone.BLL.Interfaces.Rapport_Related;
using PlayZone.BLL.Mappers.Rapport_Related;
using PlayZone.BLL.Models.Rapport_Related;
using PlayZone.DAL.Interfaces.Rapport_Related;
using PlayZone.Razor.Services;
using PlayZone.Razor.Views;

namespace PlayZone.BLL.Services.Rapport_Related;

public class RapportService : IRapportService
{
    private readonly IRapportRepository _wrr;
    private readonly PdfGenerator _pdfGenerator;
    private readonly RazorViewRendererService _razorViewRendererService;
    private readonly ILogger<RapportService> _logger;

    public RapportService(
        IRapportRepository rapportRepository,
        RazorViewRendererService razorViewRendererService,
        PdfGenerator pdfGenerator, ILogger<RapportService> logger)
    {
        this._wrr = rapportRepository;
        this._razorViewRendererService = razorViewRendererService;
        this._pdfGenerator = pdfGenerator;
        this._logger = logger;
    }

    private byte[] Generate<T>(T model, string view, string? title = null, Orientation orientation = Orientation.Portrait)
    {
        string html = this._razorViewRendererService.RenderViewToStringAsync(view, model).Result;
        return this._pdfGenerator.Execute(html, title, orientation);
    }

    public byte[] GetProjectRapport(ProjectRapport pr)
    {
        IEnumerable<ExtractProjectRapport> projectRapports = this._wrr.GetProjectRapport(pr.ToEntity()).Select(epr => epr.ToModel());

        return this.Generate(
            new ProjectRapportView(projectRapports.Select(pr => pr.ToRazor())),
            "ProjectRapportView.cshtml",
            "Rapport de comptes des projets"
        );
    }

    public byte[] GetSocialRapport(DateTime start, DateTime end)
    {
        IEnumerable<SocialRapport> socialRapports = this._wrr.GetSocialRapport(start, end).Select(s => s.ToModel());

        return this.Generate(
            new SocialRapportView(socialRapports.Select(s => s.ToRazor()), this._logger),
            "SocialRapportView.cshtml",
            $"Pointage du {start:dd MMMM yyyy} au {end:dd MMMM yyyy}",
            Orientation.Landscape
        );
    }

    public byte[] GetTimesRapport(DateTime start, DateTime end)
    {
        IEnumerable<TimesRapport> rapportProjects = this._wrr.GetTimesRapport(start, end).Select(w => w.ToModel());

        return this.Generate(
            new TimesRapportView(rapportProjects.Select(rp => rp.ToRazor())),
            "TimesRapportView.cshtml",
            "Heures Préstées par Projet"
        );
    }

    public byte[] GetCounterRapport()
    {
        List<CounterRapport> rapportWorktimes = [];
        foreach (var wk in this._wrr.GetCounterRapport())
        {
            CounterRapport? prw = rapportWorktimes.FirstOrDefault(u => u.Name == wk.Name);
            if (prw is null)
            {
                prw = new CounterRapport(wk.Name);
                rapportWorktimes.Add(prw);
            }
            prw.Counters[wk.category] = wk.Count;
        }

        return this.Generate(
            new CounterRapportView(rapportWorktimes.Select(rw => rw.ToRazor())),
            "CounterRapportView.cshtml",
            "Rapport des compteurs d'absenses"
        );
    }
}
