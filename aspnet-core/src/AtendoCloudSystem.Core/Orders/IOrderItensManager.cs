using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtendoCloudSystem.Orders
{
    public interface IOrderItensManager: IDomainService
    {
        Task<OrderItens> GetAsync(long id);

        Task CreateAsync(OrderItens @order);

        void Cancel(OrderItens @order);

        Task<OrderItens> UpdateAsync(OrderItens @order);

        Task DeleteAsync(long id);
    }
}
