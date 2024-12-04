namespace PlayZone.DAL.Entities.Budget_Related
{
    public class Transaction
    {
        public string Category { get; set; }
        public string Libele { get; set; }
        public string? Organisme { get; set; }
        public string? Motif { get; set; }
        public DateTime DateFacturation { get; set; }
        public decimal Montant { get; set; }
    }
}
