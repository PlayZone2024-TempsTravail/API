namespace PlayZone.DAL.Entities.User_Related;

public static class Permission
{
    /* Permissions sur l'utilisateur */
    public const string CONSULTER_UTILISATEUR = "VOIR_USERS";
    public const string AJOUTER_UTILISATEUR = "AJOUTER_USER";
    public const string SUPPRIMER_UTILISATEUR = "SUPPRIMER_USER";
    public const string MODIFIER_UTILISATEUR = "MODIFIER_USER";

    /* Permissions pour les pointages */
    public const string CONSULTER_SON_POINTAGE = "VOIR_POINTAGE";
    public const string CONSULTER_LES_POINTAGES = "VOIR_ALL_POINTAGES";

    public const string AJOUTER_POINTAGE = "AJOUTER_POINTAGE";
    public const string MODIFIER_POINTAGE = "MODIFIER_POINTAGE";
    public const string SUPPRIMER_POINTAGE = "SUPPRIMER_POINTAGE";

    /* Permissions pour les rôles */
    public const string CONSULTER_ROLES = "VOIR_ROLES";
    public const string CREER_ROLE = "AJOUTER_ROLE";
    public const string MODIFIER_ROLE = "MODIFIER_ROLE";
    public const string SUPPRIMER_ROLE = "SUPPRIMER_ROLE";

    public const string DEBUG_PERMISSION = "DEBUG_PERMISSION";
}
