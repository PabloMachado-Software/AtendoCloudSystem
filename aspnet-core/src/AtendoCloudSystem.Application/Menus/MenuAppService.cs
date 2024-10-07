using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.UI;
using AtendoCloudSystem.Menus.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtendoCloudSystem.Menus
{
    [AbpAuthorize]
    public class MenuAppService : AtendoCloudSystemAppServiceBase, IMenuAppService
    {
        private readonly IMenuManager _menuManager;
        private readonly IRepository<Menu, int> _menuRepository;

        public MenuAppService(
            IMenuManager menuManager,
            IRepository<Menu, int> menuRepository)
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

        public async Task<MenuDetailOutput> GetDetailAsync(EntityDto<int> input)
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
            var @menu = Menu.Create(tenantId, input.Nome, input.Categoria, input.Preco);
            await _menuManager.CreateAsync(@menu);
        }

        public async Task CancelAsync(EntityDto<int> input)
        {
            var @menu = await _menuManager.GetAsync(input.Id);
            _menuManager.Cancel(@menu);
        }

        public async Task DeleteAsync(int id)
        {
            await _menuManager.DeleteAsync(id);
        }

        public async Task<MenuDetailOutput> UpdateAsync(CreateMenuInput input)
        {
            var menu = input.MapTo<Menu>();
            var menuUpdated = await _menuManager.UpdateAsync(menu);
            return menuUpdated.MapTo<MenuDetailOutput>();
        }
    }
}
