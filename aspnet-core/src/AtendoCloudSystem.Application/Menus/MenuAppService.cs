using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Abp.Runtime.Session;
using Abp.UI;
using AtendoCloudSystem.Authorization.Users;
using AtendoCloudSystem.Events.Dto;
using AtendoCloudSystem.Menus.Dto;
using AtendoCloudSystem.Tables.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtendoCloudSystem.Menus
{
    [AbpAuthorize]
    public class MenuAppService : AtendoCloudSystemAppServiceBase, IMenuAppService
    {
        private readonly IMenuManager _menuManager;
        private readonly IRepository<Menu, Guid> _menuRepository;

        public MenuAppService(
            IMenuManager menuManager,
            IRepository<Menu, Guid> menuRepository)
        {
            _menuManager = menuManager;
            _menuRepository = menuRepository;
        }

        public async Task<ListResultDto<MenuListDto>> GetListAsync(GetMenuListInput input)
        {
            var menus = await _menuRepository
                .GetAll()
                .ToListAsync();

            return new ListResultDto<MenuListDto>(menus.MapTo<List<MenuListDto>>());
        }

        public async Task<MenuDetailOutput> GetDetailAsync(EntityDto<Guid> input)
        {
            var @menu = await _menuRepository
                .GetAll().Where(e => e.Id == input.Id)
                .FirstOrDefaultAsync();

            if (@menu == null)
            {
                throw new UserFriendlyException("Could not found the table, maybe it's deleted.");
            }

            return @menu.MapTo<MenuDetailOutput>();
        }

        public async Task CreateAsync(CreateMenuInput input)
        {
            var tenantId = AbpSession.TenantId.Value;
            var @menu = Menu.Create(tenantId,input.Nome, input.Categoria,input.Preco);
            await _menuManager.CreateAsync(@menu);
        }

        public async Task CancelAsync(EntityDto<Guid> input)
        {
            var @menu = await _menuManager.GetAsync(input.Id);
            _menuManager.Cancel(@menu);
        }
      
    }
}
