using Abp.Events.Bus;

namespace AtendoCloudSystem.Domain.Tables
{
    public static class DomainTables
    {
        public static IEventBus EventBus { get; set; }

        static DomainTables()
        {
            EventBus = Abp.Events.Bus.EventBus.Default;
        }
    }
}
