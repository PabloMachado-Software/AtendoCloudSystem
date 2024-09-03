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

        private readonly IRepository<Table, Guid> _tableRepository;

        public TableManager(

            IRepository<Table, Guid> tableRepository)
        {
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
            @table.Cancel();
            EventBus.Trigger(new TableCancelledEvent(@table));
        }
              
    }
}
