using Abp.Configuration;
using Abp.Domain.Repositories;
using Abp.Timing;
using Abp.UI;
using AtendoCloudSystem.Authorization.Users;
using AtendoCloudSystem.Configuration;
using System;
using System.Threading.Tasks;

namespace AtendoCloudSystem.Menus
{
    public class MenuRegistrationPolicy : IMenuRegistrationPolicy
    {
        private readonly IRepository<MenuRegistration> _menuRegistrationRepository;
        private readonly ISettingManager _settingManager;

        public MenuRegistrationPolicy(
            IRepository<MenuRegistration> menuRegistrationRepository,
            ISettingManager settingManager
            )
        {
            _menuRegistrationRepository = menuRegistrationRepository;
            _settingManager = settingManager;
        }

        public async Task CheckRegistrationAttemptAsync(Menu @menu, User user)
        {
            if (@menu == null) { throw new ArgumentNullException("menu"); }
            if (user == null) { throw new ArgumentNullException("user"); }

            CheckEventDate(@menu);
            await CheckEventRegistrationFrequencyAsync(user);
        }

        private static void CheckEventDate(Menu @menu)
        {
            //if (@menu.IsInPast())
            //{
            //    throw new UserFriendlyException("Can not register event in the past!");
            //}
        }

        private async Task CheckEventRegistrationFrequencyAsync(User user)
        {
            //var oneMonthAgo = Clock.Now.AddDays(-30);
            //var maxAllowedEventRegistrationCountInLast30DaysPerUser = await _settingManager.GetSettingValueAsync<int>(AppSettingNames.MaxAllowedEventRegistrationCountInLast30DaysPerUser);
            //if (maxAllowedEventRegistrationCountInLast30DaysPerUser > 0)
            //{
            //    var registrationCountInLast30Days = await _menuRegistrationRepository.CountAsync(r => r.UserId == user.Id && r.CreationTime >= oneMonthAgo);
            //    if (registrationCountInLast30Days > maxAllowedEventRegistrationCountInLast30DaysPerUser)
            //    {
            //        throw new UserFriendlyException(string.Format("Can not register to more than {0}", maxAllowedEventRegistrationCountInLast30DaysPerUser));
            //    }
            //}
        }
    }
}
