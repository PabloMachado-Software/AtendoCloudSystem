using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using AtendoCloudSystem.Orders;

namespace AtendoCloudSystem.Payments
{
    [Table("AppPayments")]
    public class Payment : FullAuditedEntity<int>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }

        public virtual long  OrderID { get; set; }

        public virtual Order Order { get; set; }

        public virtual string TipoPagamento { get; set; }

        public virtual decimal ValorTotal { get; set; }

        public virtual decimal Desconto { get; set; }

        public virtual bool IsCancelled { get; set; }


        protected Payment()
        {

        }

        public static Payment Create(int tenantId, long orderID, string tipoPagamento, decimal valorTotal, decimal desconto)
        {
            var @payment = new Payment
            {
                TenantId = tenantId,
                OrderID = orderID,
                TipoPagamento = tipoPagamento,
                ValorTotal = valorTotal,
                Desconto = desconto
            };

            return @payment;
        }


        internal void Cancel()
        {
            IsCancelled = true;
        }
    }
}


