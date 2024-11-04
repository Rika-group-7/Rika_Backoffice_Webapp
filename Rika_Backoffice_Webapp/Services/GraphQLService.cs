using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Rika_Backoffice_Webapp.Data;

namespace Rika_Backoffice_Webapp.Services;

public class GraphQLService
{
    private readonly GraphQLHttpClient _graphqlClient =
    new GraphQLHttpClient("**APIADRESS**", new NewtonsoftJsonSerializer());


    //GET ALL PRODUCTS
    private readonly GraphQLRequest _getProducts = new GraphQLRequest
    {
        Query = @"
            query GetProducts {
                Product {
                    id
                    name
                    Price
                  }
            }
        ",
        OperationName = "GetProducts"
    };

    public async Task<GraphQLResponse<GetAllProductsData>> GetProducts()
    {
        var fetch = await _graphqlClient.SendQueryAsync<GetAllProductsData>(_getProducts);

        return fetch;
    }

    //CREATE PRODUCT
    public async Task CreateProduct(string name, int price)
    {
        var createProductMutation = new GraphQLRequest
        {
            Query = @"
                mutation CreateProduct($name: String!, $price: Int!) {
                    createProduct(name: $name, price: $price) {
                        name
                        price
                    }
                }
            ",
            OperationName = "CreateProduct",
            Variables = new
            {
                name,
                price
            }
        };
        await _graphqlClient.SendMutationAsync<CreateProductData>(createProductMutation);
    } 
}
