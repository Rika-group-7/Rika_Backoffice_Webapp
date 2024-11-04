namespace Rika_Backoffice_Webapp.Models;

public class GetAllProductsRequest
{
    public IEnumerable<Product> Products { get; set; } = null!;
}
