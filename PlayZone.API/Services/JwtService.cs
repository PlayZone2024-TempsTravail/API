using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using PlayZone.API.DTOs.User_Related;
using PlayZone.API.Mappers.User_Related;
using PlayZone.BLL.Interfaces.User_Related;
using PlayZone.BLL.Models.User_Related;

namespace PlayZone.API.Services;

public class JwtService
{
    private readonly IConfiguration _config;
    private readonly IRolePermissionService _rolePermissionService;
    private readonly IUserRoleService _userRoleService;

    public JwtService(
        IConfiguration config,
        IRolePermissionService rolePermissionService,
        IUserRoleService userRoleService
    )
    {
        this._config = config;
        this._rolePermissionService = rolePermissionService;
        this._userRoleService = userRoleService;
    }

    public string GenerateToken(UserLoginDTO user)
    {
        List<Claim> claims =
        [
            new Claim(ClaimTypes.NameIdentifier, user.IdUser.ToString()),
            new Claim(ClaimTypes.Expiration, DateTime.UtcNow.AddDays(1).ToString("o")),
            new Claim("nom", user.Nom),
            new Claim("prenom", user.Prenom),
            new Claim("email", user.Email)
        ];

        foreach (UserRoleDTO ur in this._userRoleService.GetByUser(user.IdUser).Select(ur => ur.ToDTO()))
        {
            foreach (RolePermission rolePermission in this._rolePermissionService.GetByRole(ur.RoleId))
            {
                claims.Add(new Claim("Permissions", rolePermission.PermissionId));
            }
        }

        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._config["Jwt:Key"]!));
        SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken token = new JwtSecurityToken(
            this._config["Jwt:Issuer"],
            this._config["Jwt:Audience"],
            claims,
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
