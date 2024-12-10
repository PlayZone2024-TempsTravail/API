namespace PlayZone.BLL.Models.Rapport_Related;

public class CounterRapport
{
    public string Name { get; set; }
    public Dictionary<string, int> Counters;

    public CounterRapport(string name)
    {
        this.Name = name;
        this.Counters = new Dictionary<string, int>();
    }
}
