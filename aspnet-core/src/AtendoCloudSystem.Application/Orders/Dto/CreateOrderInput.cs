using Abp.Application.Services.Dto;
using AtendoCloudSystem.Authorization.Users;
using AtendoCloudSystem.Tables;
using System;
using System.ComponentModel.DataAnnotations;

namespace AtendoCloudSystem.Orders.Dto
{
    public class CreateOrderInput
    {
        public string Status { get; set; }

        public DateTime DataHora { get; set; }

        public int TableId { get; set; }
    }
}

