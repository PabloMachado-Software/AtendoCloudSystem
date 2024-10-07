using Abp.AutoMapper;
using AtendoCloudSystem.Orders;
using AtendoCloudSystem.Orders.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtendoCloudSystem.Payments.Dto
{
    [AutoMapFrom(typeof(Payment))]
    public class PaymentDetailOutput
    {
        public OrderDetailOutput Order { get; set; }

        public string TipoPagamento { get; set; }

        public decimal ValorTotal { get; set; }

        public decimal Desconto { get; set; }

        public bool IsCancelled { get; set; }
    }
}
