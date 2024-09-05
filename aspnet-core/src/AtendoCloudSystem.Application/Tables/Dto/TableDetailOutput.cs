using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AtendoCloudSystem.Tables.Dto
{
    [AutoMapFrom(typeof(Table))]
    public class TableDetailOutput : FullAuditedEntityDto<int>
    {
        public string Numero { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public bool IsCancelled { get; set; }
    }
}
