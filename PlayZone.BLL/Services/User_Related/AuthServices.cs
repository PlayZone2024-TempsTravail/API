using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using PlayZone.BLL.Interfaces.User_Related;
using PlayZone.DAL.Entities.User_Related;
using User = PlayZone.BLL.Models.User_Related.User;

namespace PlayZone.BLL.Services.User_Related;

public class AuthServices : IAuthService
{

    private readonly IConfiguration _config;

    public AuthServices(IConfiguration config)
    {
        this._config = config;
    }

    public string GenerateToken(User user)
    {

        List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, user.IdUser.ToString()),
            new Claim(ClaimTypes.Expiration, DateTime.UtcNow.AddDays(1).ToString("o")),
            new Claim("nom", user.Nom),
            new Claim("prenom", user.Prenom),
            new Claim("Permissions", "//TODO "),
        };

        // Création d'une clé symétrique avec le JWT:KEY (appsettings.json)
        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        // Signe l'algorithme hmacsha256);
        SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // Rassemblement de l'issuer, l'audience, des claims, de la date d'expiration, de la signature
        JwtSecurityToken token = new JwtSecurityToken(
            this._config["Jwt:Issuer"],
            this._config["Jwt:Audience"],
            claims,
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: creds
        );

        // Conversion en une chaine de charactère
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}


