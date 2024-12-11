using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PlayZone.Razor.Models;

namespace PlayZone.Razor.Views;

public class SocialRapportView : PageModel
{
    public IEnumerable<int> Days;
    public List<User> Users;
    private readonly ILogger _logger;

    public SocialRapportView(IEnumerable<SocialRapport> socials, ILogger logger)
    {
        this._logger = logger;
        this.Days = socials.Select(s => s.Date.Day).Distinct();

        this.Users = new List<User>();
        this._logger.LogInformation(socials.Count().ToString());
        foreach (SocialRapport socialRapport in socials)
        {
            User? user = this.Users.FirstOrDefault(u => u.NomComplet.Equals(socialRapport.NomComplet));
            if (user == null)
            {
                user = new User(socialRapport);
                this.Users.Add(user);
            }
            user.AddSocialRapport(socialRapport);
        }

        foreach (User user in this.Users)
        {
            this._logger.LogInformation($"{user.NomComplet} Matin:{user.Matins.Count} Soir:{user.Soirs.Count}");
        }
    }
}

public class User
{
    public int UserId { get; set; }
    public string NomComplet { get; set; }

    public List<Journee> Matins { get; set; }
    public List<Journee> Soirs { get; set; }

    public User(SocialRapport socialRapport)
    {
        this.UserId = socialRapport.UserId;
        this.NomComplet = socialRapport.NomComplet;
        this.Matins = new List<Journee>();
        this.Soirs = new List<Journee>();
    }

    public void AddSocialRapport(SocialRapport socialRapport)
    {
        if (socialRapport.Period == "matin")
            this.Matins.Add(new Journee(socialRapport));
        else
            this.Soirs.Add(new Journee(socialRapport));
    }
}

public class Journee
{
    public DateTime Date { get; set; }
    public string Activite { get; set; }
    public bool IsWK => Date.DayOfWeek == DayOfWeek.Saturday || Date.DayOfWeek == DayOfWeek.Sunday;

    public Journee(SocialRapport socialRapport)
    {
        this.Date = socialRapport.Date;
        this.Activite = socialRapport.Activite;
    }
}

