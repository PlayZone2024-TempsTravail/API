namespace PlayZone.DAL.Entities.Budget_Related
{
    public class Transaction
    {
        public string Type { get; set; } // Type de la transaction ('d' pour Depense, 'r' pour Rentree)
        public int Id { get; set; } // Id de la transaction (id_depense ou id_rentree)
        public int LibeleId { get; set; } // Id du libele
        public string LibeleName { get; set; } // Nom du libele joint depuis la table Libele
        public int ProjectId { get; set; } // Id du projet
        public int? OrganismeId { get; set; } // Id de l'organisme, nullable
        public decimal Montant { get; set; } // Montant de la transaction
        public DateTime? DateFacturation { get; set; } // Date de facturation, nullable
        public string Motif { get; set; } // Motif de la transaction
        public string CategoryName { get; set; } // Nom de la catégorie joint depuis la table Category
    }
}
