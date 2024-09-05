using Abp.Domain.Repositories;
using Abp.Events.Bus;
using Abp.UI;
using AtendoCloudSystem.Authorization.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtendoCloudSystem.Menus
{
    public class MenuManager : IMenuManager
    {
        public IEventBus EventBus { get; set; }
        private readonly IRepository<Menu, int> _menuRepository;

        public MenuManager(
            IRepository<Menu, int> menuRepository)
        {
            _menuRepository = menuRepository;

            EventBus = NullEventBus.Instance;
        }

        public async Task<Menu> GetAsync(int id)
        {
            var @menu = await _menuRepository.FirstOrDefaultAsync(id);
            if (@menu == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted!");
            }

            return @menu;
        }

        public async Task CreateAsync(Menu @menu)
        {
            await _menuRepository.InsertAsync(@menu);
        }

        public void Cancel(Menu @menu)
        {
            @menu.Cancel();
            EventBus.Trigger(new MenuCancelledEvent(@menu));
        } 
    }
}
