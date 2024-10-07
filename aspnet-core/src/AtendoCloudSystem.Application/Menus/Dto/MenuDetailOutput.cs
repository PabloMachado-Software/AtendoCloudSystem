using Abp.Application.Services.Dto;
using Abp.AutoMapper;

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

