﻿namespace PlayZone.BLL.Models.User_Related;

public class User
{
    public int IdUser { get; set; }
    public string RoleId { get; set; }
    public bool IsActive { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public int HeuresAnnuellesPrestables { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int VA { get; set; }
    public int VAEX { get; set; }
    public int RC { get; set; }
}
