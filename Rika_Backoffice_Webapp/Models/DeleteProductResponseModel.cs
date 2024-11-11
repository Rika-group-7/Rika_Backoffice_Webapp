using Newtonsoft.Json;

namespace Rika_Backoffice_Webapp.Models;

public class DeleteProductResponseModel
{
    [JsonProperty("deleteProduct")]
    public bool? Deleted { get; set; }
}