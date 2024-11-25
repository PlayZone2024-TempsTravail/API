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
            Date = configuration.Date,
            ParameterName = configuration.ParameterName,
            ParameterValue = configuration.ParameterValue
        };
    }

    public static Models.Configuration ToModels(this ConfigurationCreateFormDTO user)
    {
        return new Models.Configuration
        {
            IdConfiguration = configuration.IdConfiguration,
            Date = configuration.Date,
            ParameterName = configuration.ParameterName,
            ParameterValue = configuration.ParameterValue
        };
    }

    public static Models.Configuration ToModels(this ConfigurationDTO configuration)
    {
        return new Models.Configuration
        {
            IdConfiguration = configuration.IdConfiguration,
            Date = configuration.Date,
            ParameterName = configuration.ParameterName,
            ParameterValue = configuration.ParameterValue
        };
    }
}
