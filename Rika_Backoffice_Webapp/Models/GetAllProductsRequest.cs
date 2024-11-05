using Newtonsoft.Json;

namespace Rika_Backoffice_Webapp.Models;

public class GetAllProductsRequest
{
    [JsonProperty("getProducts")]
    public IEnumerable<Product> Products { get; set; } = null!;
}
