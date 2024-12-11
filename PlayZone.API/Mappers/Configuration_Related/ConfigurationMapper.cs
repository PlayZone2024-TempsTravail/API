using PlayZone.API.DTOs.Configuration_Related;
using Models = PlayZone.BLL.Models.Configuration_Related;

namespace PlayZone.API.Mappers.Configuration_Related;

public static class ConfigurationMapper
{
    public static ConfigurationDTO ToDTO(this Models.Configuration configuration)
    {
        return new ConfigurationDTO
        {
            IdConfiguration = configuration.IdConfiguration,
            ParameterName = configuration.ParameterName,
            ParameterValue = configuration.ParameterValue
        };
    }

    public static Models.Configuration ToModel(this ConfigurationCreateFormDTO configuration)
    {
        return new Models.Configuration
        {
            ParameterName = configuration.ParameterName,
            ParameterValue = configuration.ParameterValue
        };
    }
}
