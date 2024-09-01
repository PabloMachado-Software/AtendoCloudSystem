using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using Abp.UI;
using AtendoCloudSystem.Domain.Tables;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AtendoCloudSystem.Tables
{
    [Table("AppTables")]
    public class Table : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public const int MaxNumeroLength = 3;
        public const int MaxDescriptionLength = 2048;

        public virtual int TenantId { get; set; }

        [Required]
        public virtual string numero { get; protected set; }

        public virtual string Description { get; protected set; }

        public virtual string Status { get; protected set; }


        [ForeignKey("TableId")]
        public virtual ICollection<TableRegistration> Registrations { get; protected set; }

        /// <summary>
        /// We don't make constructor public and forcing to create Tables using <see cref="Create"/> method.
        /// But constructor can not be private since it's used by EntityFramework.
        /// Thats why we did it protected.
        /// </summary>
        protected Table()
        {

        }

        public static Table Create(int tenantId, string status, DateTime date, string description = null)
        {
            var @Table = new Table
            {
                Id = Guid.NewGuid(),
                TenantId = tenantId,
                Status = status,
                CreatorUserId = tenantId,
                Description = description,
            };

           @Table.Registrations = new Collection<TableRegistration>();

            return @Table;
        }
    }
}
