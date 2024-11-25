using PlayZone.BLL.Models.Worktime_Related;

namespace PlayZone.BLL.Interfaces.Worktime_Related;

public interface IWorktimeService
{
    public int Create(Worktime worktime);

    public Worktime? GetById(int id);
    public IEnumerable<Worktime> GetByDay(int idUser, int dayOfMonth);
    public IEnumerable<Worktime> GetByWeek(int idUser, int weekOfYear);
    public IEnumerable<Worktime> GetByMonth(int idUser, int monthOfYear);
}
