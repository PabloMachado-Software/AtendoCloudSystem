using Abp.Domain.Repositories;
using Abp.Events.Bus;
using Abp.UI;
using AtendoCloudSystem.Authorization.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtendoCloudSystem.Tables
{
    public class TableManager : ITableManager
    {
        public IEventBus EventBus { get; set; }

        private readonly ITableRegistrationPolicy _registrationPolicy;
        private readonly IRepository<TableRegistration> _tableRegistrationRepository;
        private readonly IRepository<Table, Guid> _tableRepository;

        public TableManager(
            ITableRegistrationPolicy registrationPolicy,
            IRepository<TableRegistration> tableRegistrationRepository,
            IRepository<Table, Guid> tableRepository)
        {
            _registrationPolicy = registrationPolicy;
            _tableRegistrationRepository = tableRegistrationRepository;
            _tableRepository = tableRepository;

            EventBus = NullEventBus.Instance;
        }

        public async Task<Table> GetAsync(Guid id)
        {
            var @table = await _tableRepository.FirstOrDefaultAsync(id);
            if (@table == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted!");
            }

            return @table;
        }

        public async Task CreateAsync(Table @table)
        {
            await _tableRepository.InsertAsync(@table);
        }

        public void Cancel(Table @table)
        {
            //@table.Cancel();
            //EventBus.Trigger(new TableCancelledEvent(@table));
        }

        public async Task<TableRegistration> RegisterAsync(Table @table, User user)
        {
            return await _tableRegistrationRepository.InsertAsync(
                await TableRegistration.CreateAsync(@table, user, _registrationPolicy)
                );
        }

        public async Task CancelRegistrationAsync(Table @table, User user)
        {
            var registration = await _tableRegistrationRepository.FirstOrDefaultAsync(r => r.TableId == @table.Id && r.UserId == user.Id);
            if (registration == null)
            {
                //No need to cancel since there is no such a registration
                return;
            }

            await registration.CancelAsync(_tableRegistrationRepository);
        }

        public async Task<IReadOnlyList<User>> GetRegisteredUsersAsync(Table @table)
        {
            return await _tableRegistrationRepository
                .GetAll()
                .Include(registration => registration.User)
                .Where(registration => registration.TableId == @table.Id)
                .Select(registration => registration.User)
                .ToListAsync();
        }
    }
}
