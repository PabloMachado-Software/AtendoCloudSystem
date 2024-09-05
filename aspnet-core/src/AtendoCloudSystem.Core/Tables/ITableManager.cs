using Abp.Domain.Services;
using AtendoCloudSystem.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtendoCloudSystem.Tables
{
    public interface ITableManager : IDomainService
    {
        Task<Table> GetAsync(int id);

        Task CreateAsync(Table @table);

        void Cancel(Table @table);

    }
}
