using Blazorise.Extensions;
using Rika_Backoffice_Webapp.Models;
using System.Linq.Expressions;

namespace Rika_Backoffice_Webapp.Services;

public class OrderService
{
    private readonly HttpClient _httpClient;

    public OrderService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    
    public async Task<List<OrderModel>> GetAllOrdersAsync()
    {
        var response = await _httpClient.GetAsync("https://orderprovider-e8cvakccb9adgpep.northeurope-01.azurewebsites.net/api/order/getall");
        if(response.IsSuccessStatusCode)
        {
            var data = await response.Content.ReadFromJsonAsync<List<OrderModel>>();
            if (data != null)
            {
                return data;
            }
        }

        return new List<OrderModel>();

    }

    public async Task<OrderModel> GetOrderByOrderNumberAsync(int orderNumber)
    {
        var response = await _httpClient.GetAsync($"https://orderprovider-e8cvakccb9adgpep.northeurope-01.azurewebsites.net/api/order/ordernumber/{orderNumber}");
        if (response.IsSuccessStatusCode)
        {
            var data = await response.Content.ReadFromJsonAsync<OrderModel>();
            if (data != null)
            {
                return data;
            }
        }
        return null!;
    }
}
