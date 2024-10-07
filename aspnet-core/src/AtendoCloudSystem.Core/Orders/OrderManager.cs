using Abp.Domain.Repositories;
using Abp.Events.Bus;
using Abp.UI;
using AtendoCloudSystem.Authorization.Users;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtendoCloudSystem.Orders
{
    public class OrderManager : IOrderManager
    {
        public IEventBus EventBus { get; set; }
        private readonly IRepository<Order, long> _orderRepository;

        public OrderManager(
            IRepository<Order, long> orderRepository)
        {
            _orderRepository = orderRepository;
            EventBus = NullEventBus.Instance;
        }

        public async Task<Order> GetAsync(long id)
        {
            var @order = await _orderRepository.FirstOrDefaultAsync(id);
            if (@order == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted!");
            }

            return @order;
        }

        public async Task CreateAsync(Order @order)
        {
            await _orderRepository.InsertAsync(@order);
        }

        public void Cancel(Order @order)
        {
            @order.Cancel();
            EventBus.Trigger(new OrderCancelledEvent(@order));
        }

        public async Task<Order> UpdateAsync(Order @order)
        {
            return await _orderRepository.UpdateAsync(@order);
        }

        public async Task DeleteAsync(long id)
        {
            await _orderRepository.DeleteAsync(id);
        }
    }
}
