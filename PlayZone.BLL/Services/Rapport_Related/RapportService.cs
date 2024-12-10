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
    private readonly IWorktimeRapportRepository _wrr;
    private readonly PdfGenerator _pdfGenerator;
    private readonly RazorViewRendererService _razorViewRendererService;
    private readonly ILogger<RapportService> _logger;

    public RapportService(
        IWorktimeRapportRepository worktimeRapportRepository,
        RazorViewRendererService razorViewRendererService,
        PdfGenerator pdfGenerator, ILogger<RapportService> logger)
    {
        this._wrr = worktimeRapportRepository;
        this._razorViewRendererService = razorViewRendererService;
        this._pdfGenerator = pdfGenerator;
        this._logger = logger;
    }

    private byte[] Generate<T>(T model, string view, string? title = null)
    {
        string html = this._razorViewRendererService.RenderViewToStringAsync(view, model).Result;
        return this._pdfGenerator.Execute(html, title);
    }

    public byte[] GetCounterRapport()
    {
        List<CounterRapport> rapportWorktimes = [];
        foreach (var wk in this._wrr.GetAll())
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

    public byte[] GetTimesRapport(DateTime start, DateTime end)
    {
        IEnumerable<TimesRapport> rapportProjects = this._wrr.GetTotalDaysProject(start, end).Select(w => w.ToModel());

        return this.Generate(
            new TimesRapportView(rapportProjects.Select(rp => rp.ToRazor())),
            "TimesRapportView.cshtml",
            "Heures Préstées par Projet"
        );
    }
}
