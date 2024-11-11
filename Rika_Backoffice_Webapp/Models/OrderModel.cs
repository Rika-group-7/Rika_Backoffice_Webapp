namespace Rika_Backoffice_Webapp.Models
{
    public class OrderModel
    {
        public string CustomerId { get; set; } = null!;
        public string CustomerEmail { get; set; } = null!;
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();
    }

    public class OrderItemDto
    {
        public string ProductId { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public string? Size { get; set; }
        public string? Color { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

}

