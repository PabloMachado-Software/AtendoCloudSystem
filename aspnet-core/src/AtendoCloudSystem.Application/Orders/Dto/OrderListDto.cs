using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;

namespace AtendoCloudSystem.Orders.Dto
{
    [AutoMapFrom(typeof(Order))]
    public class OrderListDto : FullAuditedEntityDto<long>
    {
        public string Status { get; set; }

        public DateTime DataHora { get; set; }

        public int TableId { get; set; }

        public bool IsCancelled { get; set; }
    }
}


