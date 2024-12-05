namespace PlayZone.API.Views;


public class PdfTemplate
{
    public IEnumerable<Category> mesdepenses = [];

    public PdfTemplate()
    {
        mesdepenses = new List<Category>
        {
            new Category
            {
                CategoryName = "Dépenses Opérationnelles",
                Libeles = new List<Libele>
                {
                    new Libele
                    {
                        LibeleName = "Fournitures de Bureau",
                        InOuts = new List<InOut>
                        {
                            new InOut { Date = Convert.ToDateTime("2023-01-15"), Montant = 150.00, Motif = "Achat de papier et stylos" },
                            new InOut { Date = Convert.ToDateTime("2023-02-20"), Montant = 200.00, Motif = "Achat de cartouches d'encre" },
                            new InOut { Date = Convert.ToDateTime("2023-03-25"), Montant = 120.00, Motif = "Achat de classeurs et chemises" },
                            new InOut { Date = Convert.ToDateTime("2023-04-30"), Montant = 180.00, Motif = "Achat de post-it et marqueurs" },
                            new InOut { Date = Convert.ToDateTime("2023-05-10"), Montant = 100.00, Motif = "Achat de cahiers et bloc-notes" },
                            new InOut { Date = Convert.ToDateTime("2023-06-15"), Montant = 130.00, Motif = "Achat de stylos plume" },
                            new InOut { Date = Convert.ToDateTime("2023-07-20"), Montant = 90.00, Motif = "Achat de gommes et crayons" },
                            new InOut { Date = Convert.ToDateTime("2023-08-25"), Montant = 110.00, Motif = "Achat de pochettes plastiques" },
                            new InOut { Date = Convert.ToDateTime("2023-09-30"), Montant = 140.00, Motif = "Achat de ruban adhésif" },
                            new InOut { Date = Convert.ToDateTime("2023-10-15"), Montant = 160.00, Motif = "Achat de ciseaux et cutters" },
                            new InOut { Date = Convert.ToDateTime("2023-11-20"), Montant = 170.00, Motif = "Achat de perforatrices" },
                            new InOut { Date = Convert.ToDateTime("2023-12-25"), Montant = 190.00, Motif = "Achat de trombones et élastiques" }
                        }
                    },
                    new Libele
                    {
                        LibeleName = "Frais de Déplacement",
                        InOuts = new List<InOut>
                        {
                            new InOut { Date = Convert.ToDateTime("2023-04-10"), Montant = 300.00, Motif = "Déplacement à Paris pour réunion" },
                            new InOut { Date = Convert.ToDateTime("2023-05-15"), Montant = 450.00, Motif = "Déplacement à Lyon pour conférence" },
                            new InOut { Date = Convert.ToDateTime("2023-06-20"), Montant = 250.00, Motif = "Déplacement à Marseille pour formation" },
                            new InOut { Date = Convert.ToDateTime("2023-07-25"), Montant = 350.00, Motif = "Déplacement à Bordeaux pour séminaire" },
                            new InOut { Date = Convert.ToDateTime("2023-08-10"), Montant = 280.00, Motif = "Déplacement à Lille pour atelier" },
                            new InOut { Date = Convert.ToDateTime("2023-09-15"), Montant = 320.00, Motif = "Déplacement à Strasbourg pour réunion" },
                            new InOut { Date = Convert.ToDateTime("2023-10-20"), Montant = 290.00, Motif = "Déplacement à Nantes pour conférence" },
                            new InOut { Date = Convert.ToDateTime("2023-11-25"), Montant = 310.00, Motif = "Déplacement à Toulouse pour formation" },
                            new InOut { Date = Convert.ToDateTime("2023-12-30"), Montant = 330.00, Motif = "Déplacement à Nice pour séminaire" },
                            new InOut { Date = Convert.ToDateTime("2024-01-10"), Montant = 340.00, Motif = "Déplacement à Rennes pour atelier" },
                            new InOut { Date = Convert.ToDateTime("2024-02-15"), Montant = 360.00, Motif = "Déplacement à Montpellier pour réunion" }
                        }
                    },
                    new Libele
                    {
                        LibeleName = "Frais de Représentation",
                        InOuts = new List<InOut>
                        {
                            new InOut { Date = Convert.ToDateTime("2023-03-01"), Montant = 150.00, Motif = "Déjeuner d'affaires" },
                            new InOut { Date = Convert.ToDateTime("2023-04-15"), Montant = 200.00, Motif = "Dîner avec clients" },
                            new InOut { Date = Convert.ToDateTime("2023-05-30"), Montant = 120.00, Motif = "Cadeaux clients" },
                            new InOut { Date = Convert.ToDateTime("2023-06-15"), Montant = 180.00, Motif = "Frais de réception" },
                            new InOut { Date = Convert.ToDateTime("2023-07-30"), Montant = 100.00, Motif = "Frais de transport clients" },
                            new InOut { Date = Convert.ToDateTime("2023-08-15"), Montant = 130.00, Motif = "Frais de logement clients" },
                            new InOut { Date = Convert.ToDateTime("2023-09-30"), Montant = 90.00, Motif = "Frais de divertissement clients" },
                            new InOut { Date = Convert.ToDateTime("2023-10-15"), Montant = 110.00, Motif = "Frais de communication clients" },
                            new InOut { Date = Convert.ToDateTime("2023-11-30"), Montant = 140.00, Motif = "Frais de documentation clients" },
                            new InOut { Date = Convert.ToDateTime("2023-12-15"), Montant = 160.00, Motif = "Frais de publicité clients" }
                        }
                    }
                }
            },
            new Category
            {
                CategoryName = "Revenus",
                Libeles = new List<Libele>
                {
                    new Libele
                    {
                        LibeleName = "Ventes de Produits",
                        InOuts = new List<InOut>
                        {
                            new InOut { Date = Convert.ToDateTime("2023-07-01"), Montant = 1200.00, Motif = "Vente de produits en ligne" },
                            new InOut { Date = Convert.ToDateTime("2023-08-05"), Montant = 1500.00, Motif = "Vente de produits en magasin" },
                            new InOut { Date = Convert.ToDateTime("2023-09-10"), Montant = 1300.00, Motif = "Vente de produits en gros" },
                            new InOut { Date = Convert.ToDateTime("2023-10-15"), Montant = 1400.00, Motif = "Vente de produits en promotion" },
                            new InOut { Date = Convert.ToDateTime("2023-11-20"), Montant = 1600.00, Motif = "Vente de produits en ligne" },
                            new InOut { Date = Convert.ToDateTime("2023-12-25"), Montant = 1700.00, Motif = "Vente de produits en magasin" },
                            new InOut { Date = Convert.ToDateTime("2024-01-10"), Montant = 1800.00, Motif = "Vente de produits en gros" },
                            new InOut { Date = Convert.ToDateTime("2024-02-15"), Montant = 1900.00, Motif = "Vente de produits en promotion" },
                            new InOut { Date = Convert.ToDateTime("2024-03-20"), Montant = 2000.00, Motif = "Vente de produits en ligne" },
                            new InOut { Date = Convert.ToDateTime("2024-04-25"), Montant = 2100.00, Motif = "Vente de produits en magasin" },
                            new InOut { Date = Convert.ToDateTime("2024-05-30"), Montant = 2200.00, Motif = "Vente de produits en gros" }
                        }
                    },
                    new Libele
                    {
                        LibeleName = "Services Rendus",
                        InOuts = new List<InOut>
                        {
                            new InOut { Date = Convert.ToDateTime("2023-10-15"), Montant = 800.00, Motif = "Consultation en marketing" },
                            new InOut { Date = Convert.ToDateTime("2023-11-20"), Montant = 950.00, Motif = "Formation en gestion de projet" },
                            new InOut { Date = Convert.ToDateTime("2023-12-25"), Montant = 750.00, Motif = "Consultation en développement logiciel" },
                            new InOut { Date = Convert.ToDateTime("2024-01-10"), Montant = 1000.00, Motif = "Formation en cybersécurité" },
                            new InOut { Date = Convert.ToDateTime("2024-02-15"), Montant = 1100.00, Motif = "Consultation en marketing digital" },
                            new InOut { Date = Convert.ToDateTime("2024-03-20"), Montant = 1200.00, Motif = "Formation en gestion de projet agile" },
                            new InOut { Date = Convert.ToDateTime("2024-04-25"), Montant = 1300.00, Motif = "Consultation en développement mobile" },
                            new InOut { Date = Convert.ToDateTime("2024-05-30"), Montant = 1400.00, Motif = "Formation en intelligence artificielle" },
                            new InOut { Date = Convert.ToDateTime("2024-06-10"), Montant = 1500.00, Motif = "Consultation en marketing de contenu" },
                            new InOut { Date = Convert.ToDateTime("2024-07-15"), Montant = 1600.00, Motif = "Formation en gestion de la chaîne d'approvisionnement" },
                            new InOut { Date = Convert.ToDateTime("2024-08-20"), Montant = 1700.00, Motif = "Consultation en développement web" }
                        }
                    },
                    new Libele
                    {
                        LibeleName = "Abonnements et Licences",
                        InOuts = new List<InOut>
                        {
                            new InOut { Date = Convert.ToDateTime("2023-09-01"), Montant = 500.00, Motif = "Abonnement logiciel CRM" },
                            new InOut { Date = Convert.ToDateTime("2023-10-15"), Montant = 600.00, Motif = "Licence logiciel de comptabilité" },
                            new InOut { Date = Convert.ToDateTime("2023-11-30"), Montant = 450.00, Motif = "Abonnement plateforme de marketing" },
                            new InOut { Date = Convert.ToDateTime("2023-12-15"), Montant = 700.00, Motif = "Licence logiciel de gestion de projet" },
                            new InOut { Date = Convert.ToDateTime("2024-01-30"), Montant = 550.00, Motif = "Abonnement logiciel de gestion des ressources humaines" },
                            new InOut { Date = Convert.ToDateTime("2024-02-15"), Montant = 650.00, Motif = "Licence logiciel de gestion de la relation client" },
                            new InOut { Date = Convert.ToDateTime("2024-03-30"), Montant = 520.00, Motif = "Abonnement plateforme de e-commerce" },
                            new InOut { Date = Convert.ToDateTime("2024-04-15"), Montant = 720.00, Motif = "Licence logiciel de gestion de la chaîne d'approvisionnement" },
                            new InOut { Date = Convert.ToDateTime("2024-05-30"), Montant = 580.00, Motif = "Abonnement logiciel de gestion de la paie" },
                            new InOut { Date = Convert.ToDateTime("2024-06-15"), Montant = 680.00, Motif = "Licence logiciel de gestion des stocks" }
                        }
                    }
                }
            },
            new Category
            {
                CategoryName = "Dépenses de Marketing",
                Libeles = new List<Libele>
                {
                    new Libele
                    {
                        LibeleName = "Publicité en Ligne",
                        InOuts = new List<InOut>
                        {
                            new InOut { Date = Convert.ToDateTime("2023-01-10"), Montant = 500.00, Motif = "Campagne Google Ads" },
                            new InOut { Date = Convert.ToDateTime("2023-02-15"), Montant = 600.00, Motif = "Campagne Facebook Ads" },
                            new InOut { Date = Convert.ToDateTime("2023-03-20"), Montant = 450.00, Motif = "Campagne LinkedIn Ads" },
                            new InOut { Date = Convert.ToDateTime("2023-04-25"), Montant = 700.00, Motif = "Campagne Instagram Ads" },
                            new InOut { Date = Convert.ToDateTime("2023-05-10"), Montant = 550.00, Motif = "Campagne Twitter Ads" },
                            new InOut { Date = Convert.ToDateTime("2023-06-15"), Montant = 650.00, Motif = "Campagne Pinterest Ads" },
                            new InOut { Date = Convert.ToDateTime("2023-07-20"), Montant = 520.00, Motif = "Campagne Snapchat Ads" },
                            new InOut { Date = Convert.ToDateTime("2023-08-25"), Montant = 720.00, Motif = "Campagne TikTok Ads" },
                            new InOut { Date = Convert.ToDateTime("2023-09-30"), Montant = 580.00, Motif = "Campagne YouTube Ads" },
                            new InOut { Date = Convert.ToDateTime("2023-10-15"), Montant = 680.00, Motif = "Campagne Bing Ads" },
                            new InOut { Date = Convert.ToDateTime("2023-11-20"), Montant = 750.00, Motif = "Campagne Reddit Ads" }
                        }
                    },
                    new Libele
                    {
                        LibeleName = "Événements et Salons",
                        InOuts = new List<InOut>
                        {
                            new InOut { Date = Convert.ToDateTime("2023-05-10"), Montant = 1200.00, Motif = "Participation à un salon professionnel" },
                            new InOut { Date = Convert.ToDateTime("2023-06-15"), Montant = 1500.00, Motif = "Organisation d'un événement client" },
                            new InOut { Date = Convert.ToDateTime("2023-07-20"), Montant = 1300.00, Motif = "Participation à une conférence" },
                            new InOut { Date = Convert.ToDateTime("2023-08-25"), Montant = 1400.00, Motif = "Organisation d'un webinaire" },
                            new InOut { Date = Convert.ToDateTime("2023-09-30"), Montant = 1600.00, Motif = "Participation à un salon international" },
                            new InOut { Date = Convert.ToDateTime("2023-10-15"), Montant = 1700.00, Motif = "Organisation d'un événement de lancement" },
                            new InOut { Date = Convert.ToDateTime("2023-11-20"), Montant = 1800.00, Motif = "Participation à une exposition" },
                            new InOut { Date = Convert.ToDateTime("2023-12-25"), Montant = 1900.00, Motif = "Organisation d'un séminaire" },
                            new InOut { Date = Convert.ToDateTime("2024-01-10"), Montant = 2000.00, Motif = "Participation à un forum" },
                            new InOut { Date = Convert.ToDateTime("2024-02-15"), Montant = 2100.00, Motif = "Organisation d'un atelier" },
                            new InOut { Date = Convert.ToDateTime("2024-03-20"), Montant = 2200.00, Motif = "Participation à une foire commerciale" }
                        }
                    },
                    new Libele
                    {
                        LibeleName = "Matériel Promotionnel",
                        InOuts = new List<InOut>
                        {
                            new InOut { Date = Convert.ToDateTime("2023-04-01"), Montant = 300.00, Motif = "Achat de bannières publicitaires" },
                            new InOut { Date = Convert.ToDateTime("2023-05-15"), Montant = 400.00, Motif = "Impression de brochures" },
                            new InOut { Date = Convert.ToDateTime("2023-06-30"), Montant = 250.00, Motif = "Achat de goodies promotionnels" },
                            new InOut { Date = Convert.ToDateTime("2023-07-15"), Montant = 350.00, Motif = "Impression de flyers" },
                            new InOut { Date = Convert.ToDateTime("2023-08-30"), Montant = 280.00, Motif = "Achat de stands d'exposition" },
                            new InOut { Date = Convert.ToDateTime("2023-09-15"), Montant = 320.00, Motif = "Impression de catalogues" },
                            new InOut { Date = Convert.ToDateTime("2023-10-30"), Montant = 290.00, Motif = "Achat de panneaux publicitaires" },
                            new InOut { Date = Convert.ToDateTime("2023-11-15"), Montant = 310.00, Motif = "Impression de posters" },
                            new InOut { Date = Convert.ToDateTime("2023-12-30"), Montant = 330.00, Motif = "Achat de kakémonos" },
                            new InOut { Date = Convert.ToDateTime("2024-01-15"), Montant = 340.00, Motif = "Impression de dépliants" }
                        }
                    }
                }
            },
            new Category
            {
                CategoryName = "Dépenses de R&D",
                Libeles = new List<Libele>
                {
                    new Libele
                    {
                        LibeleName = "Recherche et Développement",
                        InOuts = new List<InOut>
                        {
                            new InOut { Date = Convert.ToDateTime("2023-09-10"), Montant = 2000.00, Motif = "Développement de nouveaux produits" },
                            new InOut { Date = Convert.ToDateTime("2023-10-15"), Montant = 2200.00, Motif = "Recherche sur de nouvelles technologies" },
                            new InOut { Date = Convert.ToDateTime("2023-11-20"), Montant = 2100.00, Motif = "Tests et prototypes" },
                            new InOut { Date = Convert.ToDateTime("2023-12-25"), Montant = 2300.00, Motif = "Brevets et propriété intellectuelle" },
                            new InOut { Date = Convert.ToDateTime("2024-01-10"), Montant = 2400.00, Motif = "Développement de logiciels" },
                            new InOut { Date = Convert.ToDateTime("2024-02-15"), Montant = 2500.00, Motif = "Recherche sur l'intelligence artificielle" },
                            new InOut { Date = Convert.ToDateTime("2024-03-20"), Montant = 2600.00, Motif = "Tests de performance" },
                            new InOut { Date = Convert.ToDateTime("2024-04-25"), Montant = 2700.00, Motif = "Développement de prototypes" },
                            new InOut { Date = Convert.ToDateTime("2024-05-30"), Montant = 2800.00, Motif = "Brevets et droits d'auteur" },
                            new InOut { Date = Convert.ToDateTime("2024-06-10"), Montant = 2900.00, Motif = "Recherche sur les matériaux" },
                            new InOut { Date = Convert.ToDateTime("2024-07-15"), Montant = 3000.00, Motif = "Développement de nouvelles technologies" }
                        }
                    },
                    new Libele
                    {
                        LibeleName = "Formation et Développement des Compétences",
                        InOuts = new List<InOut>
                        {
                            new InOut { Date = Convert.ToDateTime("2023-08-01"), Montant = 1000.00, Motif = "Formation en développement logiciel" },
                            new InOut { Date = Convert.ToDateTime("2023-09-15"), Montant = 1200.00, Motif = "Formation en gestion de projet" },
                            new InOut { Date = Convert.ToDateTime("2023-10-30"), Montant = 1100.00, Motif = "Formation en marketing digital" },
                            new InOut { Date = Convert.ToDateTime("2023-11-15"), Montant = 1300.00, Motif = "Formation en cybersécurité" },
                            new InOut { Date = Convert.ToDateTime("2023-12-30"), Montant = 1400.00, Motif = "Formation en intelligence artificielle" },
                            new InOut { Date = Convert.ToDateTime("2024-01-15"), Montant = 1500.00, Motif = "Formation en développement mobile" },
                            new InOut { Date = Convert.ToDateTime("2024-02-28"), Montant = 1600.00, Motif = "Formation en gestion de la chaîne d'approvisionnement" },
                            new InOut { Date = Convert.ToDateTime("2024-03-15"), Montant = 1700.00, Motif = "Formation en développement web" },
                            new InOut { Date = Convert.ToDateTime("2024-04-30"), Montant = 1800.00, Motif = "Formation en marketing de contenu" },
                            new InOut { Date = Convert.ToDateTime("2024-05-15"), Montant = 1900.00, Motif = "Formation en gestion de projet agile" }
                        }
                    }
                }
            },
            new Category
            {
                CategoryName = "Dépenses Administratives",
                Libeles = new List<Libele>
                {
                    new Libele
                    {
                        LibeleName = "Frais de Bureau",
                        InOuts = new List<InOut>
                        {
                            new InOut { Date = Convert.ToDateTime("2023-01-01"), Montant = 200.00, Motif = "Loyer du bureau" },
                            new InOut { Date = Convert.ToDateTime("2023-02-15"), Montant = 150.00, Motif = "Électricité" },
                            new InOut { Date = Convert.ToDateTime("2023-03-30"), Montant = 100.00, Motif = "Eau" },
                            new InOut { Date = Convert.ToDateTime("2023-04-15"), Montant = 120.00, Motif = "Internet" },
                            new InOut { Date = Convert.ToDateTime("2023-05-30"), Montant = 140.00, Motif = "Chauffage" },
                            new InOut { Date = Convert.ToDateTime("2023-06-15"), Montant = 160.00, Motif = "Entretien du bureau" },
                            new InOut { Date = Convert.ToDateTime("2023-07-30"), Montant = 180.00, Motif = "Sécurité" },
                            new InOut { Date = Convert.ToDateTime("2023-08-15"), Montant = 200.00, Motif = "Nettoyage" },
                            new InOut { Date = Convert.ToDateTime("2023-09-30"), Montant = 220.00, Motif = "Assurance" },
                            new InOut { Date = Convert.ToDateTime("2023-10-15"), Montant = 240.00, Motif = "Maintenance informatique" },
                            new InOut { Date = Convert.ToDateTime("2023-11-30"), Montant = 260.00, Motif = "Frais de parking" }
                        }
                    },
                    new Libele
                    {
                        LibeleName = "Frais de Personnel",
                        InOuts = new List<InOut>
                        {
                            new InOut { Date = Convert.ToDateTime("2023-02-01"), Montant = 3000.00, Motif = "Salaires" },
                            new InOut { Date = Convert.ToDateTime("2023-03-15"), Montant = 500.00, Motif = "Primes" },
                            new InOut { Date = Convert.ToDateTime("2023-04-30"), Montant = 400.00, Motif = "Formation" },
                            new InOut { Date = Convert.ToDateTime("2023-05-15"), Montant = 300.00, Motif = "Cotisations sociales" },
                            new InOut { Date = Convert.ToDateTime("2023-06-30"), Montant = 200.00, Motif = "Frais de déplacement personnel" },
                            new InOut { Date = Convert.ToDateTime("2023-07-15"), Montant = 250.00, Motif = "Frais de repas personnel" },
                            new InOut { Date = Convert.ToDateTime("2023-08-30"), Montant = 350.00, Motif = "Frais de logement personnel" },
                            new InOut { Date = Convert.ToDateTime("2023-09-15"), Montant = 450.00, Motif = "Frais de santé personnel" },
                            new InOut { Date = Convert.ToDateTime("2023-10-30"), Montant = 550.00, Motif = "Frais de transport personnel" },
                            new InOut { Date = Convert.ToDateTime("2023-11-15"), Montant = 650.00, Motif = "Frais de communication personnel" },
                            new InOut { Date = Convert.ToDateTime("2023-12-30"), Montant = 750.00, Motif = "Frais de formation personnel" }
                        }
                    }
                }
            }
        };
    }
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
