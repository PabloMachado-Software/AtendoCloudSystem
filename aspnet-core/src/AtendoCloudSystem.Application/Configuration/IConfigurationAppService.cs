using System.Threading.Tasks;
using AtendoCloudSystem.Configuration.Dto;

namespace AtendoCloudSystem.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
