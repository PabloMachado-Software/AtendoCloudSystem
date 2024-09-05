﻿using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AtendoCloudSystem.Orders.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtendoCloudSystem.Orders
{
    public interface IOrderAppService : IApplicationService
    {
        Task<ListResultDto<OrderListDto>> GetListAsync(GetOrderListInput input);

        Task<OrderDetailOutput> GetDetailAsync(EntityDto<long> input);

        Task CreateAsync(CreateOrderInput input);

        Task CancelAsync(EntityDto<long> input);
      
    }
}
