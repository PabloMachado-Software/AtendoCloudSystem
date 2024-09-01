using Abp.Authorization;
using AtendoCloudSystem.Authorization.Roles;
using AtendoCloudSystem.Authorization.Users;

namespace AtendoCloudSystem.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
