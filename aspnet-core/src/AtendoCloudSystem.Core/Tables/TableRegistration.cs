using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Repositories;
using Abp.UI;
using AtendoCloudSystem.Authorization.Users;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace AtendoCloudSystem.Tables
{
    [Table("AppTableRegistrations")]
    public class TableRegistration : CreationAuditedEntity, IMustHaveTenant
    {
        public int TenantId { get; set; }

        public virtual Table Table { get; protected set; }
        public virtual Guid TableId { get; protected set; }

        [ForeignKey("UserId")]
        public virtual User User { get; protected set; }
        public virtual long UserId { get; protected set; }

        /// <summary>
        /// We don't make constructor public and forcing to create registrations using <see cref="CreateAsync"/> method.
        /// But constructor can not be private since it's used by EntityFramework.
        /// Thats why we did it protected.
        /// </summary>
        protected TableRegistration()
        {

        }

        public static async Task<TableRegistration> CreateAsync(Table @table, User user, ITableRegistrationPolicy registrationPolicy)
        {
            await registrationPolicy.CheckRegistrationAttemptAsync(@table, user);

            return new TableRegistration
            {
                TenantId = @table.TenantId,
                TableId = @table.Id,
                Table = @table,
                UserId = @user.Id,
                User = user
            };
        }

        public async Task CancelAsync(IRepository<TableRegistration> repository)
        {
            if (repository == null) { throw new ArgumentNullException("repository"); }

            //if (Table.IsInPast())
            //{
            //    throw new UserFriendlyException("Can not cancel event which is in the past!");
            //}

            //if (Table.IsAllowedCancellationTimeEnded())
            //{
            //    throw new UserFriendlyException("It's too late to cancel your registration!");
            //}

            await repository.DeleteAsync(this);
        }
    }
}
