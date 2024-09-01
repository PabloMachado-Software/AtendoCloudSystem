using Abp.Configuration;
using Abp.Domain.Repositories;
using Abp.Timing;
using Abp.UI;
using AtendoCloudSystem.Authorization.Users;
using AtendoCloudSystem.Configuration;
using System;
using System.Threading.Tasks;

namespace AtendoCloudSystem.Tables
{
    public class TableRegistrationPolicy : ITableRegistrationPolicy
    {
        private readonly IRepository<TableRegistration> _tableRegistrationRepository;
        private readonly ISettingManager _settingManager;

        public TableRegistrationPolicy(
            IRepository<TableRegistration> tableRegistrationRepository,
            ISettingManager settingManager
            )
        {
            _tableRegistrationRepository = tableRegistrationRepository;
            _settingManager = settingManager;
        }

        public async Task CheckRegistrationAttemptAsync(Table @table, User user)
        {
            if (@table == null) { throw new ArgumentNullException("table"); }
            if (user == null) { throw new ArgumentNullException("user"); }

            //CheckEventDate(@table);
            //await CheckEventRegistrationFrequencyAsync(user);
        }

        private static void CheckEventDate(Table @table)
        {
            //if (@table.IsInPast())
            //{
            //    throw new UserFriendlyException("Can not register Table in the past!");
            //}
        }

        private async Task CheckEventRegistrationFrequencyAsync(User user)
        {
            //var oneMonthAgo = Clock.Now.AddDays(-30);
            var maxAllowedEventRegistrationCountInLast30DaysPerUser = await _settingManager.GetSettingValueAsync<int>(AppSettingNames.MaxAllowedEventRegistrationCountInLast30DaysPerUser);
            //if (maxAllowedEventRegistrationCountInLast30DaysPerUser > 0)
            //{
            //    var registrationCountInLast30Days = await _tableRegistrationRepository.CountAsync(r => r.UserId == user.Id && r.CreationTime >= oneMonthAgo);
            //    if (registrationCountInLast30Days > maxAllowedEventRegistrationCountInLast30DaysPerUser)
            //    {
            //        throw new UserFriendlyException(string.Format("Can not register to more than {0}", maxAllowedEventRegistrationCountInLast30DaysPerUser));
            //    }
            //}
        }
    }
}
