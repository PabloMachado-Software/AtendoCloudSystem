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

        private readonly IRepository<Table, int> _tableRepository;

        public TableManager(

            IRepository<Table, int> tableRepository)
        {
            _tableRepository = tableRepository;
            EventBus = NullEventBus.Instance;
        }

        public async Task<Table> GetAsync(int id)
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

        public async void Cancel(Table @table)
        {
            @table.Cancel();
            EventBus.Trigger(new TableCancelledEvent(@table));
        }

        public async Task<Table> UpdateAsync(Table @table)
        {
            return await _tableRepository.UpdateAsync(@table);
        }

        public async Task DeleteAsync(int id)
        {
            await _tableRepository.DeleteAsync(id);
        }
    }
}

