namespace PlayZone.DAL.Entities.User_Related;

public class Permission
{
    /* Permissions sur l'utilisateur */
    public static Permission ConsulterUtilisateur => new Permission("VOIR_USERS");
    public static Permission AjouterUtilisateur => new Permission("AJOUTER_USER");
    public static Permission SupprimerUtilisateur => new Permission("SUPPRIMER_USER");
    public static Permission ModifierUtilisateur => new Permission("MODIFIER_USER");

    /* Permissions pour les pointages */
    public static Permission ConsulterSonPointage => new Permission("VOIR_POINTAGE");
    public static Permission ConsulterLesPointages => new Permission("VOIR_ALL_POINTAGES");

    public static Permission AjouterPointage => new Permission("AJOUTER_POINTAGE");
    public static Permission ModifierPointage => new Permission("MODIFIER_POINTAGE");
    public static Permission SupprimerPointage => new Permission("SUPPRIMER_POINTAGE");

    /* Permissions pour les rôles */
    public static Permission ConsulterRoles => new Permission("VOIR_ROLES");
    public static Permission CreerRole => new Permission("AJOUTER_ROLE");
    public static Permission ModifierRole => new Permission("MODIFIER_ROLE");
    public static Permission SupprimerRole => new Permission("SUPPRIMER_ROLE");

    public string permission_id { get; }
    private Permission(string perm)
    {
        this.permission_id = perm;
    }
}


