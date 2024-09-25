using Abp.Application.Services.Dto;

namespace AtendoCloudSystem.Orders.Dto
{
    public class GetOrderListInput
    {
        public bool IncludeCanceledOrders { get; set; }

        public int TableId { get; set; }
    }
}
