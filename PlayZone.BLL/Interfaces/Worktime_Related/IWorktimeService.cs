using PlayZone.BLL.Models.Worktime_Related;

namespace PlayZone.BLL.Interfaces.Worktime_Related;

public interface IWorktimeService
{
    public Worktime? GetById(int id);
    public IEnumerable<Worktime> GetByDateRange(int userId, DateTime startDate, DateTime endDate);
    public IEnumerable<Worktime> GetByDay(int userId, int dayOfMonth, int monthOfYear, int year);
    public IEnumerable<Worktime> GetByWeek(int userId, int weekOfYear, int year);
    public IEnumerable<Worktime> GetByMonth(int userId, int monthOfYear, int year);
    public int Create(Worktime worktime);
    public bool Update(Worktime worktime);
    public bool Delete(int id);
}
