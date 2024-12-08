namespace PlayZone.DAL.Entities.User_Related;

public class Permission
{
    /* Permissions sur l'utilisateur */
    public const string CONSULTER_UTILISATEUR = "VOIR_USERS";
    public const string AJOUTER_UTILISATEUR = "AJOUTER_USER";
    public const string SUPPRIMER_UTILISATEUR = "SUPPRIMER_USER";
    public const string MODIFIER_UTILISATEUR = "MODIFIER_USER";

    /* Permissions pour les pointages */
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

    public const string DEBUG_PERMISSION = "DEBUG_PERMISSION";
}

public static class PermissionManager
{
    private static Dictionary<string, string> _dic = new Dictionary<string, string>()
    {
        { Permission.DEBUG_PERMISSION, "DEV !!!!: Permisions passe-partout" },

        { Permission.CONSULTER_UTILISATEUR, "Voir la liste des utilisateurs" },
        { Permission.AJOUTER_UTILISATEUR, "Ajouter un nouvel utilisateur" },
        { Permission.SUPPRIMER_UTILISATEUR, "Désactiver un utilisateur" },
        { Permission.MODIFIER_UTILISATEUR, "Modifier un utilisateur" },

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
    };

    public static IEnumerable<object> PermissionsList => _dic.Select(pair =>
    new {
        id = pair.Key,
        description = pair.Value
    });
}
