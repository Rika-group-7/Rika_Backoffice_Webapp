using Rika_Backoffice_Webapp.Models;
namespace Rika_Backoffice_Webapp.Services;


public class UserService
{
    private readonly HttpClient _httpClient;

    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }


    private string apiUrl = "https://rika-authenticationprovider-drfta9bhdaf0g0dr.westeurope-01.azurewebsites.net/api/User/";

    public async Task <List<UserModel>> GetAllUserAsync()
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<List<UserModel>>(apiUrl + "getallusers");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return new List<UserModel>();
        }


    }

    public async Task <UserModel> GetOneUserAsync(string userId)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<UserModel>(apiUrl + $"getbyid/{userId}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return new UserModel();
        }

    }
    public async Task<UserModel> UpdateUserAsync(string userId, UserModel updateUser)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync(apiUrl + $"updatebyid/{userId}", updateUser);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<UserModel>();


            }
            else
            {
                Console.WriteLine($"Failed to update user: {response.ReasonPhrase}");
                return new UserModel();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return new UserModel();
        }

    }

}
