using PlayZone.BLL.Interfaces.Worktime_Related;
using PlayZone.BLL.Models.Worktime_Related;
using PlayZone.DAL.Entities.Worktime_Related;
using PlayZone.DAL.Interfaces.Worktime_Related;
using PlayZone.Razor.Interfaces;

namespace PlayZone.BLL.Services.Worktime_Related;

public class WorktimeRapportService : IWorktimeRapportService
{
    private readonly IWorktimeRapportRepository _wrr;
    private readonly IGenerate _generate;
    public WorktimeRapportService(IWorktimeRapportRepository wrr, IGenerate generate)
    {
        this._wrr = wrr;
        this._generate = generate;
    }

    public string GetAll()
    {
        List<PreparedRapportWorktime> rapportWorktimes = new List<PreparedRapportWorktime>();

        foreach (var wk in this._wrr.GetAll())
        {
            PreparedRapportWorktime? prw = rapportWorktimes.FirstOrDefault(u => u.Name == wk.Name);

            if (prw is null)
            {
                prw = new PreparedRapportWorktime(wk.Name);
                rapportWorktimes.Add(prw);
            }

            prw.counters[wk.category] = wk.count;
        }

        return this._generate.WorktimeCounter();
    }
}
