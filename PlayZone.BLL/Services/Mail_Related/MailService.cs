using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using PlayZone.BLL.Interfaces.Mail_Related;

namespace PlayZone.BLL.Services.Mail_Related;

public class MailService : IMailService
{
    private readonly IConfiguration _configuration;

    public MailService(IConfiguration configuration)
    {
        this._configuration = configuration;
    }

    public async Task SendMail(string to, string subject, string message, bool isHtml = false)
    {
        try
        {
            MimeMessage email_Message = new MimeMessage();
            MailboxAddress email_From = new MailboxAddress(
                this._configuration.GetSection("smtp")["NomAffichage"]!,
                this._configuration.GetSection("smtp")["Email"]!
            );
            email_Message.From.Add(email_From);

            MailboxAddress email_To = new MailboxAddress(
                to,
                to
            );
            email_Message.To.Add(email_To);

            email_Message.Subject = subject;
            BodyBuilder emailBodyBuilder = new BodyBuilder();

            if (isHtml)
                emailBodyBuilder.HtmlBody = message;
            else
                emailBodyBuilder.HtmlBody = message;
            email_Message.Body = emailBodyBuilder.ToMessageBody();

            SmtpClient MailClient = new SmtpClient();
            MailClient.Connect(
                this._configuration.GetSection("smtp")["Host"]!,
                Convert.ToInt32(this._configuration.GetSection("smtp")["Port"]!),
                true
            );

            MailClient.Authenticate(
                this._configuration.GetSection("smtp")["Email"],
                this._configuration.GetSection("smtp")["Password"]
            );

            MailClient.Send(email_Message);
            MailClient.Disconnect(true);
            MailClient.Dispose();
        }
        catch(Exception ex)
        {
            throw new Exception($"Erreur lors de l'envoi de l'e-mail. {ex.Message}");
        }
    }
}
