using PlayZone.DAL.Entities.Worktime_Related;

namespace PlayZone.DAL.Interfaces.Worktime_Related;

public interface IWorktimeRepository
{
    public IEnumerable<Worktime> GetByDateRange(int userId, DateTime startDate, DateTime endDate);
    public IEnumerable<Worktime> GetByDay(int userId, int dayOfMonth);
    public IEnumerable<Worktime> GetByWeek(int userId, int weekOfYear);
    public IEnumerable<Worktime> GetByMonth(int userId, int monthOfYear);
    public bool Update (Worktime worktime);
}
