using Abp.Events.Bus.Entities;
using AtendoCloudSystem.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtendoCloudSystem.Payments
{
    public class PaymentCancelledEvent : EntityEventData<Payment>
    {        public PaymentCancelledEvent(Payment entity)
            : base(entity)
        {
        }
    }
}
