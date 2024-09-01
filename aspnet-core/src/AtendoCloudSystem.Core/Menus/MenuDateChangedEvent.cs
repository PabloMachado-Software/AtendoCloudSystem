using Abp.Events.Bus.Entities;

namespace AtendoCloudSystem.Menus
{
    public class MenuDateChangedEvent : EntityEventData<Menu>
    {
        public MenuDateChangedEvent(Menu entity)
            : base(entity)
        {
        }
    }
}
