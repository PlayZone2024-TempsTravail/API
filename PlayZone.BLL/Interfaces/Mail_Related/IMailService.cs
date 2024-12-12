namespace PlayZone.BLL.Interfaces.Mail_Related;

public interface IMailService
{
    public Task SendMail(string to, string subject, string message, bool isHtml = false);
}
