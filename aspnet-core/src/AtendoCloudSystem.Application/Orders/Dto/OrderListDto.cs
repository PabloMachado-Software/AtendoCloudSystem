using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using AtendoCloudSystem.Tables.Dto;
using System;

namespace AtendoCloudSystem.Orders.Dto
{
    [AutoMapFrom(typeof(Order))]
    public class OrderListDto : FullAuditedEntityDto<long>
    {
        public string Status { get; set; }

        public DateTime DataHora { get; set; }

        public TableDetailOutput Table { get; set; }

        public bool IsCancelled { get; set; }
    }
}


