namespace PlayZone.BLL.Models.Rapport_Related;

public class PreparedWorktimeRapport
{
    public string Name { get; set; }
    public Dictionary<string, int> Counters;

    public PreparedWorktimeRapport(string name)
    {
        this.Name = name;
        this.Counters = new Dictionary<string, int>();
    }
}
