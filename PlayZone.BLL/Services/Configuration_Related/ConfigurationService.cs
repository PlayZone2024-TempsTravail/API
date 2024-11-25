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
        return this._configurationRepository.GetAll().Select(c => c.ToModels());
    }

    public Configuration? GetById(int id)
    {
        return this._configurationRepository.GetById(id)?.ToModels();
    }

    public int Create(Configuration configuration)
    {
        return this._configurationRepository.Create(configuration.ToEntities());
    }

    public bool Update(Configuration configuration)
    {
        return this._configurationRepository.Update(configuration.ToEntities());
    }

    public bool Delete(int idConfiguration)
    {
        this._configurationRepository.Delete(idConfiguration);
        return this._configurationRepository.GetById(idConfiguration)?.IsActive == false;
    }
}
