﻿using PlayZone.API.DTOs.User_Related;
using PlayZone.BLL.Models.User_Related;

namespace PlayZone.API.Mappers.User_Related;

public static class UserMapper
{
    public static User ToModels(this UserDTO.UserUpdateFormDTO user)
    {
        return new User
        {
            RoleId = user.RoleId,
            Nom = user.Nom,
            Prenom = user.Prenom,
            Email = user.Email,
            Password = user.Password,
            //IsActive = user.IsActive,
            HeuresAnnuellesPrestables = user.HeuresAnnuellesPrestables,
            VA = user.VA,
            VAEX = user.VAEX,
            RC = user.RC,
        };
    }

    public static UserDTO.UserUpdateFormDTO ToDTO(this User user)
    {
        return new UserDTO.UserUpdateFormDTO
        {
            RoleId = user.RoleId,
            Nom = user.Nom,
            Prenom = user.Prenom,
            Email = user.Email,
            Password = user.Password,
            //IsActive = user.IsActive,
            HeuresAnnuellesPrestables = user.HeuresAnnuellesPrestables,
            VA = user.VA,
            VAEX = user.VAEX,
            RC = user.RC,
        };
    }
}
