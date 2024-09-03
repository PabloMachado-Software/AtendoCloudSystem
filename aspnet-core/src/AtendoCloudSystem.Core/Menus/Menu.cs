using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using Abp.UI;
using AtendoCloudSystem.Domain.Menus;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtendoCloudSystem.Menus
{
    [Table("AppMenus")]
    public class Menu : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public const int MaxTitleLength = 128;
        public const int MaxDescriptionLength = 2048;

        public virtual int TenantId { get; set; }

        [Required]
        [StringLength(MaxTitleLength)]
        public virtual string Nome { get; protected set; }

     
        public virtual string Categoria { get; protected set; }

        public virtual double Preco { get; protected set; }

        public virtual bool IsCancelled { get; protected set; }



        /// <summary>
        /// We don't make constructor public and forcing to create events using <see cref="Create"/> method.
        /// But constructor can not be private since it's used by EntityFramework.
        /// Thats why we did it protected.
        /// </summary>
        protected Menu()
        {

        }

        public static Menu Create(int tenantId, string nome, string categoria, double preco)
        {
            var @menu = new Menu
            {
                Id = Guid.NewGuid(),
                TenantId = tenantId,
                Nome = nome,
                CreatorUserId = tenantId,
                Categoria = categoria,
                Preco = preco
            };

            return @menu;
        }        
       

        internal void Cancel()
        {
            IsCancelled = true;
        }       
    }
}
