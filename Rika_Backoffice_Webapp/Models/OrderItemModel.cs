using System.ComponentModel.DataAnnotations;

namespace Rika_Backoffice_Webapp.Models
{
    public class OrderItemModel
    {
        public string ProductId { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public string? Size { get; set; }
        public string? Color { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
