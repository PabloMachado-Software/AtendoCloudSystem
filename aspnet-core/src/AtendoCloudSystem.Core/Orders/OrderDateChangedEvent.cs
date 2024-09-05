using Abp.Events.Bus.Entities;

namespace AtendoCloudSystem.Orders
{
    public class OrderDateChangedEvent : EntityEventData<Order>
    {
        public OrderDateChangedEvent(Order entity)
            : base(entity)
        {
        }
    }
}
