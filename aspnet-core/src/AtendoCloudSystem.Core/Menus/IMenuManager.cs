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
        Task<Menu> GetAsync(int id);

        Task CreateAsync(Menu @menu);

        void Cancel(Menu @menu);
        Task<Menu> UpdateAsync(Menu @menu);

        Task DeleteAsync(int id);

    }
}
