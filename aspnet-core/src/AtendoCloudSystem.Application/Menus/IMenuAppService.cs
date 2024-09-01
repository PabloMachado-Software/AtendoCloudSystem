using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AtendoCloudSystem.Menus.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtendoCloudSystem.Menus
{
    public interface IMenuAppService : IApplicationService
    {
        Task<ListResultDto<MenuListDto>> GetListAsync(GetMenuListInput input);

        Task<MenuDetailOutput> GetDetailAsync(EntityDto<Guid> input);

        Task CreateAsync(CreateMenuInput input);

        Task CancelAsync(EntityDto<Guid> input);

        Task<MenuRegisterOutput> RegisterAsync(EntityDto<Guid> input);

        Task CancelRegistrationAsync(EntityDto<Guid> input);
    }
}
