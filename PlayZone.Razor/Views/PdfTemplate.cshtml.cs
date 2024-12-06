namespace PlayZone.Razor.Views;

public class PdfTemplate
{

}



public class Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public List<Libele> Libeles { get; set; } = [];
}

public class Libele
{
    public int LibeleId { get; set; }
    public string LibeleName { get; set; } = string.Empty;
    public List<InOut> InOuts { get; set; } = [];
}

public class InOut
{
    public int InOutId { get; set; }
    public DateTime Date { get; set; }
    public double Montant { get; set; }
    public string Motif { get; set; } = string.Empty;
}
