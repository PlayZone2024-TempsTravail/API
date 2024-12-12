using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using PlayZone.BLL.Interfaces.Mail_Related;
using PlayZone.Razor.Services;
using PlayZone.Razor.Views;

namespace PlayZone.BLL.Helpers;

public class PasswordHelper
{
    private readonly IMailService _mailService;
    private readonly RazorViewRendererService _razorViewRendererService;
    private readonly IConfiguration _configuration;


    public PasswordHelper(
        IMailService mailService,
        RazorViewRendererService razorViewRendererService,
        IConfiguration configuration
    )
    {
        this._mailService = mailService;
        this._razorViewRendererService = razorViewRendererService;
        this._configuration = configuration;
    }

    public string GenerateHash(string email, string password)
    {
        using SHA256 sha256Hash = SHA256.Create() ;

        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes($"{email}:{password}"));

        StringBuilder builder = new StringBuilder();
        foreach (byte b in bytes)
        {
            builder.Append(b.ToString("x2"));
        }

        return builder.ToString();
    }

    public string GeneratePassword()
    {
        const int PASSWORD_LENGTH = 12;
        const string ALLOWED_CHARS = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890@=";
        char[] password = new char[PASSWORD_LENGTH];
        byte[] randomBytes = new byte[PASSWORD_LENGTH];

        using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomBytes);
        }

        for (int i = 0; i < PASSWORD_LENGTH; i++)
        {
            password[i] = ALLOWED_CHARS[randomBytes[i] % ALLOWED_CHARS.Length];
        }

        return new string(password);
    }

    public async Task New(string email, string nom, string prenom, string password)
    {
        string html = this._razorViewRendererService.RenderViewToStringAsync(
            "NewPasswordView.cshtml",
            new NewPasswordView
            {
                Logo = "https://zupimages.net/up/24/49/2g1w.png",
                Nom = nom,
                Prenom = prenom,
                Password = password,
                SupportMail = this._configuration.GetSection("smtp")["Email"]!
            }
        ).Result;

        await this._mailService.SendMail(
            email,
            "Réinitialisation de votre mot de passe",
            html,
            true
        );
    }
}
