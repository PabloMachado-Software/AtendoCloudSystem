using AtendoCloudSystem.Tables;
using System;
using System.ComponentModel.DataAnnotations;

namespace AtendoCloudSystem.Menus.Dto
{
    public class CreateMenuInput
    {
        [Required]
        public string Nome { get; set; }

        public string Categoria { get; set; }

        public double Preco { get; set; }

        public string  Descricao { get; set; }
    }
}