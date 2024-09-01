using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using AtendoCloudSystem.Configuration.Dto;

namespace AtendoCloudSystem.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : AtendoCloudSystemAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
