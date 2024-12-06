namespace PlayZone.BLL.Models.Worktime_Related;

public class PreparedRapportWorktime
{
    public string Name { get; set; }
    public Dictionary<string, int> counters;

    public PreparedRapportWorktime(string name)
    {
        this.Name = name;
        this.counters = new Dictionary<string, int>();
    }
}
