using PlayZone.BLL.Models.Configuration_Related;

namespace PlayZone.BLL.Interfaces.Configuration_Related;

public interface IConfigurationService
{
    public IEnumerable<Configuration> GetAll();
    public Configuration? GetById(int id);
    public int Create(Configuration configuration);
    public bool Update(Configuration configuration);
    public bool Delete(int id);
}
