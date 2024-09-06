using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AtendoCloudSystem.Menus.Dto
{
    [AutoMapFrom(typeof(Menu))]
    public class MenuDetailOutput : FullAuditedEntityDto<int>
    {
        public string Nome { get; set; }

        public string Categoria { get; set; }

        public double Preco { get; set; }

        public bool IsCancelled { get; set; }

    }
}

