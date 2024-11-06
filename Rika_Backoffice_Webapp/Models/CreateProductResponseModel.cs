using Newtonsoft.Json;

namespace Rika_Backoffice_Webapp.Models;

public class CreateProductResponseModel
{
    [JsonProperty("createProduct")]

    public ProductCreateRequest? ProductCreated { get; set; }
}
