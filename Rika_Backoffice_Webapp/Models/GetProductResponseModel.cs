using Newtonsoft.Json;

namespace Rika_Backoffice_Webapp.Models;

public class GetProductResponseModel
{
    [JsonProperty("getProductById")]
    public Product? ProductReceived { get; set; }
}
