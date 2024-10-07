using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AtendoCloudSystem.Orders.Dto;
using AtendoCloudSystem.Orders.Itens.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtendoCloudSystem.Orders.Itens
{
    public interface IOrderItensAppService: IApplicationService
    {
        Task<ListResultDto<OrderItensListDto>> GetListAsync(GetOrderItensListInput input);

        Task<ListResultDto<OrderItensListDto>> GetListByOrderAsync(GetOrderItensListInput input);

        Task<OrderItensDetailOutput> GetDetailAsync(EntityDto<long> input);

        Task CreateAsync(CreateOrderItensInput input);

        Task CancelAsync(EntityDto<long> input);

        Task<OrderItensDetailOutput> UpdateAsync(CreateOrderItensInput input);

        Task DeleteAsync(long id);
    }
}
