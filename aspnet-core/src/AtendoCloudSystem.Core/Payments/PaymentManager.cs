using Abp.Domain.Repositories;
using Abp.Events.Bus;
using Abp.UI;
using AtendoCloudSystem.Authorization.Users;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtendoCloudSystem.Payments
{
    public class PaymentManager : IPaymentManager
    {
        public IEventBus EventBus { get; set; }
        private readonly IRepository<Payment, int> _paymentRepository;

        public PaymentManager(
            IRepository<Payment, int> paymentRepository)
        {
            _paymentRepository = paymentRepository;
            EventBus = NullEventBus.Instance;
        }

        public async Task<Payment> GetAsync(int id)
        {
            var @payment = await _paymentRepository.FirstOrDefaultAsync(id);
            if (@payment == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted!");
            }

            return @payment;
        }

        public async Task CreateAsync(Payment @payment)
        {
            await _paymentRepository.InsertAsync(@payment);
        }

        public void Cancel(Payment @payment)
        {
            @payment.Cancel();
            EventBus.Trigger(new PaymentCancelledEvent(@payment));
        }

        public async Task<Payment> UpdateAsync(Payment @payment)
        {
            return await _paymentRepository.UpdateAsync(@payment);
        }

        public async Task DeleteAsync(int id)
        {
            await _paymentRepository.DeleteAsync(id);
        }
    }
}
