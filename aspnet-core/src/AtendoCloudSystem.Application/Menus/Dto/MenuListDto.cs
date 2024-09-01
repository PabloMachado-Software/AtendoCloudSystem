using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;

namespace AtendoCloudSystem.Menus.Dto
{
    [AutoMapFrom(typeof(Menu))]
    public class MenuListDto : FullAuditedEntityDto<Guid>
    {
        public string Nome { get; set; }

        public string Categoria { get; set; }

        public double Preco { get; set; }
    }
}


