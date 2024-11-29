﻿using System.ComponentModel.DataAnnotations;

namespace PlayZone.API.DTOs.Configuration_Related;

public class ConfigurationDTO
{
    public int IdConfiguration { get; set; }
    public DateTime Date { get; set; }
    public string? ParameterName { get; set; }
    public string? ParameterValue { get; set; }
}

public class ConfigurationCreateFormDTO
{
    [Required]
    public DateTime Date { get; set; }

    [Required]
    public string? ParameterName { get; set; }

    [Required]
    public string? ParameterValue { get; set; }
}