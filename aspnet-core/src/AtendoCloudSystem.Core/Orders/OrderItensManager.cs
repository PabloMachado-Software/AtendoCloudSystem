using Abp.Domain.Repositories;
using Abp.Events.Bus;
using Abp.UI;
using AtendoCloudSystem.Authorization.Users;
using AtendoCloudSystem.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtendoCloudSystem.OrderItenss
{
    public class OrderItensManager : IOrderItensManager
    {
        public IEventBus EventBus { get; set; }
        private readonly IRepository<OrderItens, long> _orderItensRepository;

        public OrderItensManager(
            IRepository<OrderItens, long> orderItensRepository)
        {
            _orderItensRepository = orderItensRepository;
            EventBus = NullEventBus.Instance;
        }

        public async Task<OrderItens> GetAsync(long id)
        {
            var @orderItens = await _orderItensRepository.FirstOrDefaultAsync(id);
            if (@orderItens == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted!");
            }

            return @orderItens;
        }

        public async Task CreateAsync(OrderItens @orderItens)
        {
            await _orderItensRepository.InsertAsync(@orderItens);
        }

        public void Cancel(OrderItens @orderItens)
        {
            @orderItens.Cancel();
            EventBus.Trigger(new OrderItensCancelledEvent(@orderItens));
        }

        public async Task<OrderItens> UpdateAsync(OrderItens @orderItens)
        {
            return await _orderItensRepository.UpdateAsync(@orderItens);
        }

        public async Task DeleteAsync(long id)
        {
            await _orderItensRepository.DeleteAsync(id);
        }
    }
}
