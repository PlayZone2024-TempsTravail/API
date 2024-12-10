namespace PlayZone.Razor.Models;

public class ProjectRapport(string name)
{
    public string Name { get; set; } = name;

    public List<Category> Categories = new List<Category>();

    public class Category(string name)
    {
        public string Name { get; set; } = name;

        public List<Libelle> Libelles = new List<Libelle>();
    }

    public class Libelle(string name)
    {
        public string Name { get; set; } = name;

        public List<InOut> InOuts = new List<InOut>();
    }

    public class InOut(string? organisme, string? motif, DateTime date, decimal montant)
    {
        public string? Organisme { get; set; } = organisme;
        public string? Motif { get; set; } = motif;
        public DateTime Date { get; set; } = date;
        public decimal Montant { get; set; } = montant;
    }
}
