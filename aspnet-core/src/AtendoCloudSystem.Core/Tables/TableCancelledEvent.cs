using Abp.Events.Bus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtendoCloudSystem.Tables
{
    public class TableCancelledEvent : EntityEventData<Table>
    {
        public TableCancelledEvent(Table entity)
            : base(entity)
        {
        }
    }
}
