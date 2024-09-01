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

        private readonly IMenuRegistrationPolicy _registrationPolicy;
        private readonly IRepository<MenuRegistration> _menuRegistrationRepository;
        private readonly IRepository<Menu, Guid> _menuRepository;

        public MenuManager(
            IMenuRegistrationPolicy registrationPolicy,
            IRepository<MenuRegistration> menuRegistrationRepository,
            IRepository<Menu, Guid> menuRepository)
        {
            _registrationPolicy = registrationPolicy;
            _menuRegistrationRepository = menuRegistrationRepository;
            _menuRepository = menuRepository;

            EventBus = NullEventBus.Instance;
        }

        public async Task<Menu> GetAsync(Guid id)
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

        public async Task<MenuRegistration> RegisterAsync(Menu @menu, User user)
        {
            return await _menuRegistrationRepository.InsertAsync(
                await MenuRegistration.CreateAsync(@menu, user, _registrationPolicy)
                );
        }

        public async Task CancelRegistrationAsync(Menu @menu, User user)
        {
            var registration = await _menuRegistrationRepository.FirstOrDefaultAsync(r => r.MenuId == @menu.Id && r.UserId == user.Id);
            if (registration == null)
            {
                //No need to cancel since there is no such a registration
                return;
            }

            await registration.CancelAsync(_menuRegistrationRepository);
        }

        public async Task<IReadOnlyList<User>> GetRegisteredUsersAsync(Menu @menu)
        {
            return await _menuRegistrationRepository
                .GetAll()
                .Include(registration => registration.User)
                .Where(registration => registration.MenuId == @menu.Id)
                .Select(registration => registration.User)
                .ToListAsync();
        }
    }
}
