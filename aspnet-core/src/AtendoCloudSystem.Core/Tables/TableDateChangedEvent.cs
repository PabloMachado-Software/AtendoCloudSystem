using Abp.Events.Bus.Entities;

namespace AtendoCloudSystem.Tables
{
    public class TableDateChangedEvent : EntityEventData<Table>
    {
        public TableDateChangedEvent(Table entity)
            : base(entity)
        {
        }
    }
}
