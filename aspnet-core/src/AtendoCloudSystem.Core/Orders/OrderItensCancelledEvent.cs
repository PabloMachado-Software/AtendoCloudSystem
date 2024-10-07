using Abp.Events.Bus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtendoCloudSystem.Orders
{
    public class OrderItensCancelledEvent : EntityEventData<OrderItens>
    {
        public OrderItensCancelledEvent(OrderItens entity)
                : base(entity)
        {

        }
    }
}
