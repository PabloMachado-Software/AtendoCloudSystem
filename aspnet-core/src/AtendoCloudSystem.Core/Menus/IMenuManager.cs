using Abp.Domain.Services;
using AtendoCloudSystem.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtendoCloudSystem.Menus

{
    public interface IMenuManager : IDomainService
    {
        Task<Menu> GetAsync(Guid id);

        Task CreateAsync(Menu @menu);

        void Cancel(Menu @menu);

        Task<MenuRegistration> RegisterAsync(Menu @menu, User user);

        Task CancelRegistrationAsync(Menu @menu, User user);

        Task<IReadOnlyList<User>> GetRegisteredUsersAsync(Menu @menu);
    }
}
