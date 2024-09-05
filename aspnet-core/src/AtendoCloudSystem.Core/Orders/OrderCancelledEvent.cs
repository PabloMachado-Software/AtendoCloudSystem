using Abp.Events.Bus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtendoCloudSystem.Orders
{
    public class OrderCancelledEvent : EntityEventData<Order>
    {
        public OrderCancelledEvent(Order entity)
            : base(entity)
        {
        }
    }
}
