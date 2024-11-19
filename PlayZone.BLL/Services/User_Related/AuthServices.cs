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

namespace PlayZone.BLL.Services.User_Related;

public class AuthServices : IAuthService
{
    private readonly IConfiguration _config;

    public AuthServices(IConfiguration config)
    {
        _config = config;
    }

    public string GenerateToken(User user)
    {
        List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NomIdentifier, User.IdUser.ToString());
        }
    }


}
