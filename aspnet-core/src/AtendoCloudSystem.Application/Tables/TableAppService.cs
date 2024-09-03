using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Abp.Runtime.Session;
using Abp.UI;
using AtendoCloudSystem.Authorization.Users;
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
        private readonly IRepository<Table, Guid> _tableRepository;

        public TableAppService(
            ITableManager tableManager,
            IRepository<Table, Guid> tableRepository)
        {
            _tableManager = tableManager;
            _tableRepository = tableRepository;
        }

        public async Task<ListResultDto<TableListDto>> GetListAsync(GetTableListInput input)
        {
            var tables = await _tableRepository
                .GetAll()
                .Include(e => e.Registrations)                
                .OrderByDescending(e => e.CreationTime)
                .Take(64)
                .ToListAsync();

            return new ListResultDto<TableListDto>(tables.MapTo<List<TableListDto>>());
        }

        public async Task<TableDetailOutput> GetDetailAsync(EntityDto<Guid> input)
        {
            var @table = await _tableRepository
                .GetAll()
                .Include(e => e.Registrations)
                .ThenInclude(r => r.User)
                .Where(e => e.Id == input.Id)
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
            var @table = Table.Create( tenantId, input.Numero,input.Description,input.Status);
            await _tableManager.CreateAsync(@table);
        }

        public async Task CancelAsync(EntityDto<Guid> input)
        {
            var @table = await _tableManager.GetAsync(input.Id);
            _tableManager.Cancel(@table);
        }

        public async Task<TableRegisterOutput> RegisterAsync(EntityDto<Guid> input)
        {
            var registration = await RegisterAndSaveAsync(
                await _tableManager.GetAsync(input.Id),
                await GetCurrentUserAsync()
                );

            return new TableRegisterOutput
            {
                RegistrationId = registration.Id
            };
        }

        public async Task CancelRegistrationAsync(EntityDto<Guid> input)
        {
            await _tableManager.CancelRegistrationAsync(
                await _tableManager.GetAsync(input.Id),
                await GetCurrentUserAsync()
                );
        }

        private async Task<TableRegistration> RegisterAndSaveAsync(Table @table, User user)
        {
            var registration = await _tableManager.RegisterAsync(@table, user);
            await CurrentUnitOfWork.SaveChangesAsync();
            return registration;
        }
    }
}
