using PlayZone.BLL.Models.Worktime_Related;

namespace PlayZone.BLL.Interfaces.Worktime_Related;

public interface IWorktimeService
{
    public IEnumerable<Worktime> GeTAll();
    public Worktime? GetById(int id);
    public int Create(Worktime worktime);
    public bool Update(Worktime worktime);
    public bool Delete(int id);
}
