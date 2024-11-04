using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtendoCloudSystem.Menus;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.EntityFrameworkCore;

namespace AtendoCloudSystem.Orders
{
    [Table("AppOrderItens")]
    public class OrderItens : FullAuditedEntity<long>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }
        public virtual long OrderId { get; set; }

        public virtual Order Order { get; set; }

        public virtual int MenuId { get; set; }

        public virtual Menu Menu { get; set; }

        public virtual int Quantidade { get; set; }

        [Precision(14, 2)]
        public virtual decimal Preco { get; set; }

        public virtual bool IsCancelled { get; set; }



        protected OrderItens()
        {

        }

        public static OrderItens Create(int tenantId, long orderId, int menu, int quantidade, decimal preco)
        {
            var @order = new OrderItens
            {
                TenantId = tenantId,
                OrderId = orderId,
                MenuId = menu,
                Quantidade = quantidade,
                Preco = preco
            };

            return @order;
        }


        internal void Cancel()
        {
            IsCancelled = true;
        }
    }
}



