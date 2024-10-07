using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.UI;
using AtendoCloudSystem.Orders.Itens.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtendoCloudSystem.Orders.Itens
{
    public class OrderItensAppService : AtendoCloudSystemAppServiceBase, IOrderItensAppService
    {
        private readonly IOrderItensManager _orderItensManager;
        private readonly IRepository<OrderItens, long> _orderItensRepository;

        public OrderItensAppService(
            IOrderItensManager orderItensManager,
            IRepository<OrderItens, long> orderItensRepository)
        {
            _orderItensManager = orderItensManager;
            _orderItensRepository = orderItensRepository;
        }

        public async Task<ListResultDto<OrderItensListDto>> GetListAsync(GetOrderItensListInput input)
        {
            var orderItens = await _orderItensRepository
                .GetAll()
                .Include( e => e.OrderId == input.OrderId)               
                .OrderByDescending(e => e.CreationTime)
                .Take(64)
                .ToListAsync();

            return new ListResultDto<OrderItensListDto>(orderItens.MapTo<List<OrderItensListDto>>());
        }

        public async Task<ListResultDto<OrderItensListDto>> GetListByOrderAsync(GetOrderItensListInput input)
        {
            var @orderItens = await _orderItensRepository
                .GetAll().Where(e => e.OrderId == input.OrderId)
                .FirstOrDefaultAsync();

            return new ListResultDto<OrderItensListDto>(orderItens.MapTo<List<OrderItensListDto>>());
        }

        public async Task<OrderItensDetailOutput> GetDetailAsync(EntityDto<long> input)
        {
            var @orderItens = await _orderItensRepository
                .GetAll().Where(e => e.Id == input.Id)
                .FirstOrDefaultAsync();

            if (@orderItens == null)
            {
                throw new UserFriendlyException("Could not found the orderItens, maybe it's deleted.");
            }

            return @orderItens.MapTo<OrderItensDetailOutput>();
        }

        public async Task CreateAsync(CreateOrderItensInput input)
        {
            var tenantId = AbpSession.TenantId.Value;
            var @orderItens = OrderItens.Create(tenantId, input.OrderId, input.MenuId,input.Quantidade, input.Preco);
            await _orderItensManager.CreateAsync(@orderItens);
        }

        public async Task CancelAsync(EntityDto<long> input)
        {
            var @orderItens = await _orderItensManager.GetAsync(input.Id);
            _orderItensManager.Cancel(@orderItens);
        }

        public async Task DeleteAsync(long id)
        {
            await _orderItensManager.DeleteAsync(id);
        }


        public async Task<OrderItensDetailOutput> UpdateAsync(CreateOrderItensInput input)
        {
            var orderItens = input.MapTo<OrderItens>();
            var orderItensUpdated = await _orderItensManager.UpdateAsync(orderItens);
            return orderItensUpdated.MapTo<OrderItensDetailOutput>();
        }        
    }
}