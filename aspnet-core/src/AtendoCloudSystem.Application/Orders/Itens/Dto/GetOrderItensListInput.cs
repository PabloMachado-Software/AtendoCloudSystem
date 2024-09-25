namespace AtendoCloudSystem.Orders.Itens.Dto
{
    public class GetOrderItensListInput
    {
        public bool IncludeCanceledOrders { get; set; }

        public long OrderId { get; set; }
    }
}
