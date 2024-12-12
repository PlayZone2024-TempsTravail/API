using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PlayZone.Razor.Views;

public class NewPasswordView : PageModel
{
    public string Logo { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public string Password { get; set; }
    public string SupportMail { get; set; }
}
