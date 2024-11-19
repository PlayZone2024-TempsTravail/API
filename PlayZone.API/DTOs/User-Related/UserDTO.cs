using System.ComponentModel.DataAnnotations;

namespace PlayZone.API.DTOs.User_Related;

public class UserDTO
{
    public class UserUpdateFormDTO
    {
        public int RoleId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        //public bool IsActive { get; set; }
        public int HeuresAnnuellesPrestables { get; set; }
        public int VA { get; set; }
        public int VAEX { get; set; }
        public int RC { get; set; }
    }
}
