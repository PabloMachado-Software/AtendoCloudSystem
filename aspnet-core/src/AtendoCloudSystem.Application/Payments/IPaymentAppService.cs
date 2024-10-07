using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AtendoCloudSystem.Orders.Dto;
using AtendoCloudSystem.Payments.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtendoCloudSystem.Payments
{
    public interface IPaymentAppService : IApplicationService
    {
        Task<ListResultDto<PaymentListDto>> GetListAsync(GetPaymentListInput input);

        Task<PaymentDetailOutput> GetDetailAsync(EntityDto<int> input);

        Task CreateAsync(CreatePaymentInput input);

        Task CancelAsync(EntityDto<int> input);

        Task<PaymentDetailOutput> UpdateAsync(PaymentListDto input);

        Task DeleteAsync(int id);
    }
}
