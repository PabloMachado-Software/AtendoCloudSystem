using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using AtendoCloudSystem.Menus.Dto;
using AtendoCloudSystem.Orders.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtendoCloudSystem.Orders.Itens.Dto
{

    [AutoMapFrom(typeof(OrderItens))]
    public class OrderItensListDto : FullAuditedEntityDto<long>
    {
        public OrderDetailOutput Order { get; set; }

        public ICollection<MenuDetailOutput> Menu { get; set; }

        public int Quantidade { get; set; }

        public decimal Preco { get; set; }

        public bool IsCancelled { get; set; }
    }
}
