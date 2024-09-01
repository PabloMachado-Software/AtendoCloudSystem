using Abp.Domain.Services;
using AtendoCloudSystem.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtendoCloudSystem.Menus
{
    public interface IMenuRegistrationPolicy : IDomainService
    {
        /// <summary>
        /// Checks if given user can register to <see cref="@menu"/> and throws exception if can not.
        /// </summary>
        Task CheckRegistrationAttemptAsync(Menu @menu, User user);
    }
}
