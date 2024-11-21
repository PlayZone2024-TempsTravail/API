using PlayZone.DAL.Entities.Worktime_Related;

namespace PlayZone.DAL.Interfaces.Worktime_Related;

public interface IWorktimeRepository
{
    public IEnumerable<Worktime> GetByDay(int idUser, int dayOfMonth);
    public IEnumerable<Worktime> GetByWeek(int idUser, int weekOfYear);
    public IEnumerable<Worktime> GetByMonth(int idUser, int monthOfYear);
}
