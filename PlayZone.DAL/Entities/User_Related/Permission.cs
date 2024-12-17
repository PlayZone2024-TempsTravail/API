namespace PlayZone.DAL.Entities.User_Related;

public class Permission
{

    /* Permissions sur l'utilisateur */
    public const string CONSULTER_UTILISATEUR = "VOIR_USERS";
    public const string AJOUTER_UTILISATEUR = "AJOUTER_USER";
    public const string SUPPRIMER_UTILISATEUR = "SUPPRIMER_USER";
    public const string MODIFIER_UTILISATEUR = "MODIFIER_USER";
    public const string EDIT_COMPTEUR = "EDITER_COMPTEUR";
    public const string EDIT_USER_SALAIRE = "EDITER_USER_SALAIRE";

    /* Permissions pour les pointages */
    public const string EDIT_WORKTIMECATEGORY = "MODIFIER_CATEGORIE_POINTAGE";

    public const string PERSO_CONSULTER_POINTAGE = "PERSO_CONSULTER_POINTAGE";
    public const string PERSO_AJOUTER_POINTAGE = "PERSO_AJOUTER_POINTAGE";
    public const string PERSO_MODIFIER_POINTAGE = "PERSO_MODIFIER_POINTAGE";
    public const string PERSO_SUPPRIMER_POINTAGE = "PERSO_SUPPRIMER_POINTAGE";

    public const string ALL_CONSULTER_POINTAGES = "ALL_CONSULTER_POINTAGES";
    public const string ALL_AJOUTER_POINTAGE = "ALL_AJOUTER_POINTAGE";
    public const string ALL_MODIFIER_POINTAGE = "ALL_MODIFIER_POINTAGE";
    public const string ALL_SUPPRIMER_POINTAGE = "ALL_SUPPRIMER_POINTAGE";

    /* Permissions pour les rôles */
    public const string CONSULTER_ROLES = "VOIR_ROLES";
    public const string CREER_ROLE = "AJOUTER_ROLE";
    public const string MODIFIER_ROLE = "MODIFIER_ROLE";
    public const string MODIFIER_PERMISSIONS = "MODIFIER_PERMISSIONS";
    public const string SUPPRIMER_ROLE = "SUPPRIMER_ROLE";


    /* Permissions pour les catégories */

    public const string EDIT_CATEGORY = "MODIFIER_CATEGORIE";
    public const string EDIT_PREVISION_CATEGORY = "MODIFIER_PREVISION_CATEGORIE";
    public const string DELETE_PREVISION_CATEGORY = "SUPPRIMER_PREVISION_CATEGORIE";

    /* Permissions pour les projets */
    public const string SHOW_PROJECTS = "VOIR_PROJETS";
    public const string CREATE_PROJECT = "AJOUTER_PROJET";
    public const string MODIFY_PROJECT = "MODIFIER_PROJET";
    public const string DELETE_PROJECT = "SUPPRIMER_PROJET";

    /* Permissions pour les Libellés */
    public const string EDIT_LIBELLE = "MODIFIER_LIBELLE";

    /* Permissions pour les Organismes */
    public const string EDIT_ORGANISME = "MODIFIER_ORGANISME";

    public const string DELETE_ORGANISME = "SUPPRIMER_ORGANISME";


    /* Permissions pour les Rentrées */
    public const string EDIT_RENTREE = "MODIFIER_RENTREE";
    public const string DELETE_RENTREE = "SUPPRIMER_RENTREE";
    public const string EDIT_PREVISION_RENTREE = "MODIFIER_PREVISION_RENTREE";
    public const string DELETE_PREVISION_RENTREE = "SUPPRIMER_PREVISION_RENTREE";

    /* Permissions pour les Depenses */
    public const string EDIT_DEPENSE = "MODIFIER_DEPENSE";
    public const string DELETE_DEPENSE = "SUPPRIMER_DEPENSE";
    public const string EDIT_PREVISION_DEPENSE = "MODIFIER_PREVISION_DEPENSE";
    public const string DELETE_PREVISION_DEPENSE = "SUPPRIMER_PREVISION_DEPENSE";

    /* Permissions pour les configurations*/
    public const string EDIT_CONFIGURATION = "MODIFIER_CONFIGURATION";

    /* Permissions pour les rapports*/
    public const string SHOW_RAPPORT = "VOIR_RAPPORT";

    /* Permissions passe-partout */
    public const string DEBUG_PERMISSION = "DEBUG_PERMISSION";
}

public static class PermissionManager
{
    private static Dictionary<string, string> _dic = new Dictionary<string, string>()
    {
        { Permission.CONSULTER_UTILISATEUR, "Voir la liste des utilisateurs" },
        { Permission.AJOUTER_UTILISATEUR, "Ajouter un nouvel utilisateur" },
        { Permission.SUPPRIMER_UTILISATEUR, "Désactiver un utilisateur" },
        { Permission.MODIFIER_UTILISATEUR, "Modifier un utilisateur" },
        { Permission.EDIT_COMPTEUR, "Modifier un compteur" },
        { Permission.EDIT_USER_SALAIRE, "Modifier le salaire d'un utilisateur" },

        { Permission.EDIT_WORKTIMECATEGORY, "Edition des catégorie de pointage" },

        { Permission.PERSO_CONSULTER_POINTAGE, "Soi-même: Voir son calendrier de pointage" },
        { Permission.PERSO_AJOUTER_POINTAGE, "Soi-même: Encoder un pointage" },
        { Permission.PERSO_MODIFIER_POINTAGE, "Soi-même: Modifier un pointage" },
        { Permission.PERSO_SUPPRIMER_POINTAGE, "Soi-même: Supprimer un pointage" },

        { Permission.ALL_CONSULTER_POINTAGES, "Admin: Voir le pointage d'un utilisateur" },
        { Permission.ALL_AJOUTER_POINTAGE, "Admin: Encoder un pointage" },
        { Permission.ALL_MODIFIER_POINTAGE, "Admin: Modifier un pointage" },
        { Permission.ALL_SUPPRIMER_POINTAGE, "Admin: Supprimer un pointage" },

        { Permission.CONSULTER_ROLES, "Voir la lists des rôles et permissions" },
        { Permission.CREER_ROLE, "Créer un role" },
        { Permission.MODIFIER_ROLE, "Modifier un role" },
        { Permission.MODIFIER_PERMISSIONS, "Modifier les permissions d'un role" },
        { Permission.SUPPRIMER_ROLE, "Supprimer un role" },

        { Permission.EDIT_CATEGORY, "Modifier une catégorie" },
        { Permission.EDIT_PREVISION_CATEGORY, "Modifier une prévision de catégorie" },
        { Permission.DELETE_PREVISION_CATEGORY, "Supprimer une prévision de catégorie" },

        { Permission.SHOW_PROJECTS, "Voir la liste des projets" },
        { Permission.CREATE_PROJECT, "Créer un projet" },
        { Permission.MODIFY_PROJECT, "Modifier un projet" },
        { Permission.DELETE_PROJECT, "Supprimer un projet" },

        { Permission.EDIT_LIBELLE, "Modifier un libellé" },

        { Permission.EDIT_ORGANISME, "Modifier un organisme" },
        { Permission.DELETE_ORGANISME, "Supprimer un organisme" },

        { Permission.EDIT_RENTREE, "Modifier une rentrée" },
        { Permission.DELETE_RENTREE, "Supprimer une rentrée" },
        { Permission.EDIT_PREVISION_RENTREE, "Modifier une prévision de rentrée" },
        { Permission.DELETE_PREVISION_RENTREE, "Supprimer une prévision de rentrée" },

        { Permission.EDIT_DEPENSE, "Modifier une dépense" },
        { Permission.DELETE_DEPENSE, "Supprimer une dépense" },
        { Permission.EDIT_PREVISION_DEPENSE, "Modifier une prévision de dépense" },
        { Permission.DELETE_PREVISION_DEPENSE, "Supprimer une prévision de dépense" },

        { Permission.EDIT_CONFIGURATION, "Modifier la configuration" },

        {Permission.SHOW_RAPPORT, "Voir les rapports" }
    };

    public static IEnumerable<object> PermissionsList => _dic.Select(pair =>
    new {
        id = pair.Key,
        description = pair.Value
    });
}
