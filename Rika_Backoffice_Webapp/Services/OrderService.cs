using Rika_Backoffice_Webapp.Models;

namespace Rika_Backoffice_Webapp.Services;

public class OrderService
{
    private readonly HttpClient _httpClient;


    public OrderService(HttpClient httpClient, UserService userService)
    {
        _httpClient = httpClient;

    }

    private string apiUrl = "https://orderprovider-e8cvakccb9adgpep.northeurope-01.azurewebsites.net/api/order/customerId/";

    public async Task<List<OrderModel>> GetOrderByUserId(string orderId)
    {

        return await _httpClient.GetFromJsonAsync<List<OrderModel>>(apiUrl + $"{orderId}");
    }

    public async Task<List<OrderItemDto>> GetOrderItemByOrderNumber(string orderId)
    {
        return await _httpClient.GetFromJsonAsync<List<OrderItemDto>>(apiUrl + $"{orderId}");
    }
}
