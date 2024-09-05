using Abp.Events.Bus;

namespace AtendoCloudSystem.Domain.Orders
{
    public static class DomainOrders
    {
        public static IEventBus EventBus { get; set; }

        static DomainOrders()
        {
            EventBus = Abp.Events.Bus.EventBus.Default;
        }
    }
}
