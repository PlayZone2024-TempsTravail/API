using PlayZone.BLL.Interfaces.Configuration_Related;
using PlayZone.DAL.Interfaces.Configuration_Related;
using PlayZone.BLL.Mappers.Configuration_Related;
using PlayZone.BLL.Models.Configuration_Related;

namespace PlayZone.BLL.Services.Configuration_Related;

public class ConfigurationService : IConfigurationService
{
    private readonly IConfigurationRepository _configurationRepository;

    public ConfigurationService(IConfigurationRepository configurationRepository)
    {
        this._configurationRepository = configurationRepository;
    }

    public IEnumerable<Configuration> GetAll()
    {
        return this._configurationRepository.GetAll().Select(c => c.ToModel());
    }

    public Configuration? GetById(int id)
    {
        return this._configurationRepository.GetById(id)?.ToModel();
    }

    public int Create(Configuration configuration)
    {
        return this._configurationRepository.Create(configuration.ToEntity());
    }
}
