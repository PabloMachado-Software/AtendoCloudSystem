using Abp.Events.Bus;

namespace AtendoCloudSystem.Domain.Orders
{
    public static class DomainPayments
    {
        public static IEventBus EventBus { get; set; }

        static DomainPayments()
        {
            EventBus = Abp.Events.Bus.EventBus.Default;
        }
    }
}
