using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using AtendoCloudSystem.Domain.Tables;

namespace AtendoCloudSystem.Tables
{
    [Table("AppTables")]
    public class Table : FullAuditedEntity<int>, IMustHaveTenant
    {
        public const int MaxNumeroLength = 3;
        public const int MaxDescriptionLength = 2048;

        public virtual int TenantId { get; set; }

        [Required]
        public virtual string Numero { get; protected set; }

        public virtual string Description { get; protected set; }

        public virtual string Status { get; protected set; }

        public virtual bool IsCancelled { get; protected set; }

        /// <summary>
        /// We don't make constructor public and forcing to create Tables using <see cref="Create"/> method.
        /// But constructor can not be private since it's used by EntityFramework.
        /// Thats why we did it protected.
        /// </summary>
        protected Table()
        {

        }

        public static Table Create(int tenantId, string numero, string description, string status)
        {
            var @Table = new Table
            {
                TenantId = tenantId,
                Numero = numero,
                Status = status,
                CreatorUserId = tenantId,
                Description = description,
            };

           return @Table;
        }


        internal void Cancel()
        {
            IsCancelled = true;
        }
    }
}
