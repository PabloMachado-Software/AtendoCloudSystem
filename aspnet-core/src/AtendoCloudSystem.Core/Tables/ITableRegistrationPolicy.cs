using Abp.Domain.Services;
using AtendoCloudSystem.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtendoCloudSystem.Tables
{
    public interface ITableRegistrationPolicy : IDomainService
    {
        /// <summary>
        /// Checks if given user can register to <see cref="@table"/> and throws exception if can not.
        /// </summary>
        Task CheckRegistrationAttemptAsync(Table @table, User user);
    }
}
