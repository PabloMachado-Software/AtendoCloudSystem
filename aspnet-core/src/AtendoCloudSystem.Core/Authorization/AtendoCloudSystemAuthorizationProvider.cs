using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace AtendoCloudSystem.Authorization
{
    public class AtendoCloudSystemAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Events, L("Events"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_Tables, L("Tables"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_Menus, L("Menus"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AtendoCloudSystemConsts.LocalizationSourceName);
        }
    }
}
