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

    public byte[] GetWorktimeCounterRapport()
    {
        List<PreparedWorktimeRapport> rapportWorktimes = new List<PreparedWorktimeRapport>();
        foreach (var wk in this._wrr.GetAll())
        {
            PreparedWorktimeRapport? prw = rapportWorktimes.FirstOrDefault(u => u.Name == wk.Name);
            if (prw is null)
            {
                prw = new PreparedWorktimeRapport(wk.Name);
                rapportWorktimes.Add(prw);
            }

            prw.Counters[wk.category] = wk.Count;
        }

        return this.Generate(
            new WorktimeRapport(rapportWorktimes.Select(rw => rw.ToRazor())),
            "WorktimeRapport.cshtml",
            "Rapport des compteurs d'absenses"
        );
    }





}
