using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Abp.Runtime.Session;
using Abp.UI;
using AtendoCloudSystem.Authorization.Users;
using AtendoCloudSystem.Orders.Dto;
using AtendoCloudSystem.Tables;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtendoCloudSystem.Orders
{
    [AbpAuthorize]
    public class OrderAppService : AtendoCloudSystemAppServiceBase, IOrderAppService
    {
        private readonly IOrderManager _orderManager;
        private readonly ITableManager _tableManager;
        private readonly IRepository<Order, long> _orderRepository;

        public OrderAppService(
            IOrderManager orderManager,
            ITableManager tableManager,
            IRepository<Order, long> orderRepository)
        {
            _orderManager = orderManager;
            _orderRepository = orderRepository;
            _tableManager = tableManager;
        }

        public async Task<ListResultDto<OrderListDto>> GetListAsync(GetOrderListInput input)
        {
            var orders = await _orderRepository
                .GetAll()
                .ToListAsync();

            return new ListResultDto<OrderListDto>(orders.MapTo<List<OrderListDto>>());
        }

        public async Task<OrderDetailOutput> GetDetailAsync(EntityDto<long> input)
        {
            var @order = await _orderRepository
                .GetAll().Where(e => e.Id == input.Id)
                .FirstOrDefaultAsync();

            if (@order == null)
            {
                throw new UserFriendlyException("Could not found the table, maybe it's deleted.");
            }

            return @order.MapTo<OrderDetailOutput>();
        }

        public async Task CreateAsync(CreateOrderInput input)
        {
            var tenantId = AbpSession.TenantId.Value;
            var table = _tableManager.GetAsync(input.TableId.Id).Result;                       

            var @order = Order.Create(tenantId,input.Status, input.DataHora, table);
            await _orderManager.CreateAsync(@order);
        }

        public async Task CancelAsync(EntityDto<long> input)
        {
            var @order = await _orderManager.GetAsync(input.Id);
            _orderManager.Cancel(@order);
        }      
    }
}
