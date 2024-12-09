using PlayZone.BLL.Models.Configuration_Related;
using Entities = PlayZone.DAL.Entities.Configuration_Related;

namespace PlayZone.BLL.Mappers.Configuration_Related;
public static class ConfigurationMapper
{
    public static Entities.Configuration ToEntity(this Configuration configuration)
    {
        return new Entities.Configuration
        {
            IdConfiguration = configuration.IdConfiguration,
            ParameterName = configuration.ParameterName,
            ParameterValue = configuration.ParameterValue
        };
    }

    public static Configuration ToModel(this Entities.Configuration configuration)
    {
        return new Configuration
        {
            IdConfiguration = configuration.IdConfiguration,
            ParameterName = configuration.ParameterName,
            ParameterValue = configuration.ParameterValue
        };
    }
}
