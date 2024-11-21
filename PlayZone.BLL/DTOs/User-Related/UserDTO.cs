using System.ComponentModel.DataAnnotations;

namespace PlayZone.BLL.DTOs.User_Related;

public class UserDTO
{

}

public class UserDeleteFromDTO
{
    [Required]
    public int IdUser { get; set; }
}
