using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.UI;
using AtendoCloudSystem.Events.Dto;
using AtendoCloudSystem.Payments.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtendoCloudSystem.Payments
{
    [AbpAuthorize]
    public class PaymentAppService : AtendoCloudSystemAppServiceBase, IPaymentAppService
    {
        private readonly IPaymentManager _paymentManager;
        private readonly IRepository<Payment, int> _paymentRepository;

        public PaymentAppService(
            IPaymentManager paymentManager,
            IRepository<Payment, int> paymentRepository)
        {
            _paymentManager = paymentManager;
            _paymentRepository = paymentRepository;
        }

        public async Task<ListResultDto<PaymentListDto>> GetListAsync(GetPaymentListInput input)
        {
            var payments = await _paymentRepository
                .GetAll()
                .OrderByDescending(e => e.CreationTime)
                .ToListAsync();

            return new ListResultDto<PaymentListDto>(payments.MapTo<List<PaymentListDto>>());
        }

        public async Task<PaymentDetailOutput> GetDetailAsync(EntityDto<int> input)
        {
            var @payment = await _paymentRepository
                .GetAll().Where(e => e.Id == input.Id)
                .FirstOrDefaultAsync();

            if (@payment == null)
            {
                throw new UserFriendlyException("Could not found the payment, maybe it's deleted.");
            }

            return @payment.MapTo<PaymentDetailOutput>();
        }

        public async Task CreateAsync(CreatePaymentInput input)
        {
            var tenantId = AbpSession.TenantId.Value;

            var @payment = Payment.Create(tenantId, input.OrderID, input.TipoPagamento, input.ValorTotal, input.Desconto);
            await _paymentManager.CreateAsync(@payment);
        }

        public async Task CancelAsync(EntityDto<int> input)
        {
            var @payment = await _paymentManager.GetAsync(input.Id);
            _paymentManager.Cancel(@payment);
        }

        public async Task DeleteAsync(int id)
        {
            await _paymentManager.DeleteAsync(id);
        }


        public async Task<PaymentDetailOutput> UpdateAsync(PaymentListDto input)
        {
            var payment = input.MapTo<Payment>();
            var paymentUpdated = await _paymentManager.UpdateAsync(payment);
            return paymentUpdated.MapTo<PaymentDetailOutput>();
        }
    }
}
