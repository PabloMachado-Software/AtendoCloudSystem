using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Repositories;
using Abp.UI;
using AtendoCloudSystem.Authorization.Users;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace AtendoCloudSystem.Menus
{
    [Table("AppMenuRegistrations")]
    public class MenuRegistration : CreationAuditedEntity, IMustHaveTenant
    {
        public int TenantId { get; set; }

        public virtual Menu Menu { get; protected set; }
        public virtual Guid MenuId { get; protected set; }

        [ForeignKey("UserId")]
        public virtual User User { get; protected set; }
        public virtual long UserId { get; protected set; }

        /// <summary>
        /// We don't make constructor public and forcing to create registrations using <see cref="CreateAsync"/> method.
        /// But constructor can not be private since it's used by EntityFramework.
        /// Thats why we did it protected.
        /// </summary>
        protected MenuRegistration()
        {

        }

        public static async Task<MenuRegistration> CreateAsync(Menu @menu, User user, IMenuRegistrationPolicy registrationPolicy)
        {
            await registrationPolicy.CheckRegistrationAttemptAsync(@menu, user);

            return new MenuRegistration
            {
                TenantId = @menu.TenantId,
                MenuId = @menu.Id,
                Menu = @menu,
                UserId = @user.Id,
                User = user
            };
        }

        public async Task CancelAsync(IRepository<MenuRegistration> repository)
        {
            if (repository == null) { throw new ArgumentNullException("repository"); }

            if (Menu.IsInPast())
            {
                throw new UserFriendlyException("Can not cancel event which is in the past!");
            }

            if (Menu.IsAllowedCancellationTimeEnded())
            {
                throw new UserFriendlyException("It's too late to cancel your registration!");
            }

            await repository.DeleteAsync(this);
        }
    }
}
