using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PlayZone.DAL.Entities.User_Related;

namespace PlayZone.API.Attributes;

public class PermissionAuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public string[] Permissions { get; }

    public PermissionAuthorizeAttribute(params string[] permissions)
    {
        this.Permissions = permissions;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        List<string> userPerm = context.HttpContext.User.Claims.Where(c => c.Type == "Permissions").Select(c => c.Value).ToList();

        bool isAuthorized = true;
        for (int i = 0; isAuthorized && i < this.Permissions.Length; i++)
        {
            if (!userPerm.Any(up => up == this.Permissions[i]))
            {
                isAuthorized = false;
            }
        }

        if (!isAuthorized)
        {
            context.Result = new ForbidResult();
        }
    }
}
