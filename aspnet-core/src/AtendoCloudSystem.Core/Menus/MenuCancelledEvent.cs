using Abp.Events.Bus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtendoCloudSystem.Menus
{
    public class MenuCancelledEvent : EntityEventData<Menu>
    {
        public MenuCancelledEvent(Menu entity)
            : base(entity)
        {
        }
    }
}
