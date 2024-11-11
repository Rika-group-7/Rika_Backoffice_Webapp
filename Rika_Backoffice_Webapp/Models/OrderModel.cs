namespace Rika_Backoffice_Webapp.Models
{
    public class OrderModel
    {
        public string CustomerId { get; set; } = null!;
        public string CustomerEmail { get; set; } = null!;
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        public List<OrderItemModel> OrderItems { get; set; } = new List<OrderItemModel>();
    }
}
