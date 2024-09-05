using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.UI;
using AtendoCloudSystem.Events.Dto;
using AtendoCloudSystem.Tables.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtendoCloudSystem.Tables
{
    [AbpAuthorize]
    public class TableAppService : AtendoCloudSystemAppServiceBase, ITableAppService
    {
        private readonly ITableManager _tableManager;
        private readonly IRepository<Table, int> _tableRepository;

        public TableAppService(
            ITableManager tableManager,
            IRepository<Table, int> tableRepository)
        {
            _tableManager = tableManager;
            _tableRepository = tableRepository;
        }

        public async Task<ListResultDto<TableListDto>> GetListAsync(GetTableListInput input)
        {
            var tables = await _tableRepository
                .GetAll()
                .OrderByDescending(e => e.CreationTime)
                .ToListAsync();

            return new ListResultDto<TableListDto>(tables.MapTo<List<TableListDto>>());
        }

        public async Task<TableDetailOutput> GetDetailAsync(EntityDto<int> input)
        {
            var @table = await _tableRepository
                .GetAll().Where(e => e.Id == input.Id)
                .FirstOrDefaultAsync();

            if (@table == null)
            {
                throw new UserFriendlyException("Could not found the table, maybe it's deleted.");
            }

            return @table.MapTo<TableDetailOutput>();
        }

        public async Task CreateAsync(CreateTableInput input)
        {
            var tenantId = AbpSession.TenantId.Value;
            var @table = Table.Create(tenantId, input.Numero, input.Description, input.Status);
            await _tableManager.CreateAsync(@table);
        }

        public async Task CancelAsync(EntityDto<int> input)
        {
            var @table = await _tableManager.GetAsync(input.Id);
            _tableManager.Cancel(@table);
        }     
    }
}
