using AtendoCloudSystem.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtendoCloudSystem.Payments
{
    public interface IPaymentManager
    {
        Task<Payment> GetAsync(int id);

        Task CreateAsync(Payment @payments);

        void Cancel(Payment @payments);

        Task<Payment> UpdateAsync(Payment @payments);

        Task DeleteAsync(int id);
    }
}
