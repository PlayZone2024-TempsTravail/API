using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using PlayZone.BLL.Interfaces.User_Related;
using PlayZone.BLL.Mappers.User_Related;
using PlayZone.DAL.Entities.User_Related;
using PlayZone.DAL.Interfaces.User_Related;
using User = PlayZone.BLL.Models.User_Related.User;

namespace PlayZone.BLL.Services.User_Related;

public class AuthServices : IAuthService
{

    private readonly IConfiguration _config;
    private readonly IUserRepository _userRepository;
    public AuthServices(IConfiguration config, IUserRepository userRepository)
    {
        this._config = config;
        this._userRepository = userRepository;
    }

    public string Login(User user)
    {
        User userDb = this._userRepository.Login(user.Email).ToModels();
        if (userDb.Email == user.Email  && userDb.Password == user.Password)
        {
            return this.GenerateToken(user);
        }
        throw new InvalidCastException();
    }

    public string GenerateToken(User user)
    {

        List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, user.IdUser.ToString()),
            new Claim(ClaimTypes.Expiration, DateTime.UtcNow.AddDays(1).ToString("o")),
            new Claim("nom", user.Nom),
            new Claim("prenom", user.Prenom),
            new Claim("Permissions", Permission.CONSULTER_UTILISATEUR),
            new Claim("Permissions", Permission.AJOUTER_UTILISATEUR),
            new Claim("Permissions", Permission.SUPPRIMER_UTILISATEUR)
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


