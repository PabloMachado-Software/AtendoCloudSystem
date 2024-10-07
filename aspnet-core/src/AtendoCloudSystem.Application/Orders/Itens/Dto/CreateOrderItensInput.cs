using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtendoCloudSystem.Orders.Itens.Dto
{
    public class CreateOrderItensInput
    {
        public long OrderId { get; set; }

        public int MenuId { get; set; }

        public int Quantidade { get; set; }

        public decimal Preco { get; set; }

    }
}
