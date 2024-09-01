using System.Threading.Tasks;
using Abp.Application.Services;
using AtendoCloudSystem.Sessions.Dto;

namespace AtendoCloudSystem.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
