using System.Threading.Tasks;
using Abp.Application.Services;
using AtendoCloudSystem.Authorization.Accounts.Dto;

namespace AtendoCloudSystem.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
