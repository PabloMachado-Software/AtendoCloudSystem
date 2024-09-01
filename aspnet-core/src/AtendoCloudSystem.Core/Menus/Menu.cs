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
        /// Gets or sets the maximum registration count.
        /// 0: Unlimited.
        /// </summary>
        [Range(0, int.MaxValue)]
        public virtual int MaxRegistrationCount { get; protected set; }

        [ForeignKey("MenuId")]
        public virtual ICollection<MenuRegistration> Registrations { get; protected set; }

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

            //@menu.SetDate(date);

            @menu.Registrations = new Collection<MenuRegistration>();

            return @menu;
        }

        public bool IsInPast()
        {
            return false;
        }

        public bool IsAllowedCancellationTimeEnded()
        {
            //return Date.Subtract(Clock.Now).TotalHours <= 2.0; //2 hours can be defined as Event property and determined per event
            return false;
        }

        public void ChangeDate(DateTime date)
        {
            //if (date == Date)
            //{
            //    return;
            //}

            //SetDate(date);

            //DomainMenus.EventBus.Trigger(new MenuDateChangedEvent(this));
        }

        internal void Cancel()
        {
            AssertNotInPast();
            IsCancelled = true;
        }

        private void SetDate(DateTime date)
        {
            //AssertNotCancelled();

            //if (date < Clock.Now)
            //{
            //    throw new UserFriendlyException("Can not set an event's date in the past!");
            //}

            //if (date <= Clock.Now.AddHours(3)) //3 can be configurable per tenant
            //{
            //    throw new UserFriendlyException("Should set an event's date 3 hours before at least!");
            //}

            //Date = date;

            //DomainMenus.EventBus.Trigger(new MenuDateChangedEvent(this));
        }

        private void AssertNotInPast()
        {
            if (IsInPast())
            {
                throw new UserFriendlyException("This event was in the past");
            }
        }

        private void AssertNotCancelled()
        {
            if (IsCancelled)
            {
                throw new UserFriendlyException("This event is canceled!");
            }
        }
    }
}
