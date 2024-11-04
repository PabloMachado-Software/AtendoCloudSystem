using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtendoCloudSystem.Payments.Dto
{
    [AutoMapFrom(typeof(Payment))]
    public class PaymentListDto
    {
        public long OrderID { get; set; }

        public string TipoPagamento { get; set; }

        public decimal ValorTotal { get; set; }

        public decimal Desconto { get; set; }

        public decimal TaxaServico { get; set; }

        public bool IsCancelled { get; set; }
    }
}
