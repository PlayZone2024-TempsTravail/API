using PlayZone.BLL.Models.Worktime_Related;

namespace PlayZone.BLL.Interfaces.Worktime_Related;

public interface IWorktimeService
{
    public IEnumerable<Worktime> GetByDateRange(int userId, DateTime startDate, DateTime endDate);
    public IEnumerable<Worktime> GetByDay(int userId, int dayOfMonth);
    public IEnumerable<Worktime> GetByWeek(int userId, int weekOfYear);
    public IEnumerable<Worktime> GetByMonth(int userId, int monthOfYear);
}
