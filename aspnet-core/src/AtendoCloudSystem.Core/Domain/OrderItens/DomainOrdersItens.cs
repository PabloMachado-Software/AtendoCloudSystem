using Abp.Events.Bus;

namespace AtendoCloudSystem.Domain.OrderItens
{
    public static class DomainOrdersItens
    {
        public static IEventBus EventBus { get; set; }

        static DomainOrdersItens()
        {
            EventBus = Abp.Events.Bus.EventBus.Default;
        }
    }
}
