using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using AtendoCloudSystem.Events.Dto;
using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AtendoCloudSystem.Orders.Dto
{
    [AutoMapFrom(typeof(Order))]
    public class OrderDetailOutput : FullAuditedEntityDto<long>
    {
        public string Status { get; set; }

        public DateTime DataHora { get; set; }


        public EntityDto<Guid> TableId { get; set; }
    }
}

