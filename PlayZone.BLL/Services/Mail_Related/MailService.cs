using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PlayZone.BLL.Interfaces.Mail_Related;
using PlayZone.Razor.Services;

namespace PlayZone.BLL.Services.Mail_Related;

public class MailService : IMailService
{
    private readonly SmtpClient _smtpClient;
    private readonly IConfiguration _configuration;
    private readonly RazorViewRendererService _razorViewRendererService;

    public MailService(SmtpClient smtpClient, IConfiguration configuration)
    {
        this._configuration = configuration;
        this._smtpClient = smtpClient;
    }

    public async Task SendMail(string to, string subject, string message, bool isHtml = false)
    {
        MailMessage mail = new MailMessage
        {
            Subject = subject,
            Body = message,
            IsBodyHtml = isHtml,
            From = new MailAddress(
                this._configuration.GetSection("smtp")["Email"]!,
                this._configuration.GetSection("smtp")["NomAffichage"]
            )
        };

        mail.To.Add(to);

        try
        {
            await this._smtpClient.SendMailAsync(mail).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            throw new Exception("Erreur lors de l'envoi de l'e-mail.", e);
        }
    }
}
