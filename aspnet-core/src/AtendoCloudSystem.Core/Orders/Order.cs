using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using Abp.UI;
using AtendoCloudSystem.Authorization.Users;
using AtendoCloudSystem.Domain.Orders;
using AtendoCloudSystem.Events;
using AtendoCloudSystem.Tables;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtendoCloudSystem.Orders
{
    [Table("AppOrders")]
    public class Order : FullAuditedEntity<long>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }

        public virtual string Status { get; protected set; }

        public virtual DateTime DataHora { get; protected set; }

        public virtual Table Table { get; protected set; }

        public virtual int TableId { get; protected set; }

        public virtual bool IsCancelled { get; protected set; }


        /// <summary>
        /// We don't make constructor public and forcing to create events using <see cref="Create"/> method.
        /// But constructor can not be private since it's used by EntityFramework.
        /// Thats why we did it protected.
        /// </summary>
        protected Order()
        {

        }

        public static Order Create(int tenantId, string status, DateTime dataHora, int tableId)
        {
            var @order = new Order
            {
                TenantId = tenantId,
                Status = status,
                CreatorUserId = tenantId,
                TableId = tableId,
            };

            return @order;
        }        
       

        internal void Cancel()
        {
            IsCancelled = true;
        }       
    }
}
