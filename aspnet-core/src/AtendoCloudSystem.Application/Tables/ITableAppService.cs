using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AtendoCloudSystem.Tables.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtendoCloudSystem.Tables
{
    public interface ITableAppService : IApplicationService
    {
        Task<ListResultDto<TableListDto>> GetListAsync(GetTableListInput input);

        Task<TableDetailOutput> GetDetailAsync(EntityDto<Guid> input);

        Task CreateAsync(CreateTableInput input);

        Task CancelAsync(EntityDto<Guid> input);
    }
}
