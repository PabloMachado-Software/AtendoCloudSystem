using Abp.Application.Services;
using AtendoCloudSystem.MultiTenancy.Dto;

namespace AtendoCloudSystem.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

