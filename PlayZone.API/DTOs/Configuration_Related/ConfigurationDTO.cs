using System.ComponentModel.DataAnnotations;

namespace PlayZone.API.DTOs.Configuration_Related;

public class ConfigurationDTO
{
    public int IdConfiguration { get; set; }
    public int Date { get; set; }
    public int ParameterName { get; set; }
    public int ParameterValue { get; set; }
}

public class ConfigurationCreateFormDTO
{
    [Required]
    public int Date { get; set; }

    [Required]
    public int ParameterName { get; set; }

    [Required]
    public int ParameterValue { get; set; }
}
