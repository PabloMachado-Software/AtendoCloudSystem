using Abp.Events.Bus;

namespace AtendoCloudSystem.Domain.Menus
{
    public static class DomainMenus
    {
        public static IEventBus EventBus { get; set; }

        static DomainMenus()
        {
            EventBus = Abp.Events.Bus.EventBus.Default;
        }
    }
}
