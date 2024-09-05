using Abp.Domain.Services;
using AtendoCloudSystem.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtendoCloudSystem.Orders

{
    public interface IOrderManager : IDomainService
    {
        Task<Order> GetAsync(long id);

        Task CreateAsync(Order @order);

        void Cancel(Order @order);
       
    }
}
