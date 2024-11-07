using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Rika_Backoffice_Webapp.Models;
using System.Diagnostics;

namespace Rika_Backoffice_Webapp.Services;

public class ProductService
{
    private readonly GraphQLHttpClient _graphqlClient =
    new GraphQLHttpClient("https://productprovider-rika.azurewebsites.net/api/graphql?code=Da4aZa9Xnh8jmwu-Srgxk8wI7NpUBsKbMxQa9hoS0kp9AzFueYwEOg%3D%3D", new NewtonsoftJsonSerializer());


    //GET ALL PRODUCTS
    private readonly GraphQLRequest _getProducts = new GraphQLRequest
    {
        Query = "query { getProducts { id title brand size color price description stockStatus sku ratings productImage categories { categoryName subCategories { categoryName } } materials { materialName } } }"
    };

    //public async Task<GraphQLResponse<GetAllProductsRequest>> GetProducts()
    //{
    //    var fetch = await _graphqlClient.SendQueryAsync<GetAllProductsRequest>(_getProducts);
        
    //    return fetch;
    //}

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        var fetch = await _graphqlClient.SendQueryAsync<GetAllProductsRequest>(_getProducts);

        return fetch?.Data?.Products?.AsEnumerable() ?? Enumerable.Empty<Product>();
    }

    //CREATE PRODUCT
    public async Task<GraphQLResponse<CreateProductResponseModel>> CreateProduct(ProductCreateRequest input)
    {
        var createProductMutation = new GraphQLRequest
        {

            Query = @"
            mutation ($input: ProductCreateRequestInput!) {
                createProduct(input: $input) {
                    id
                    title
                    brand
                    size
                    color
                    price
                    description
                    stockStatus
                    sku
                    ratings
                    productImage
                    categories {
                        categoryName
                        subCategories {
                            categoryName
                        }
                    }
                    materials {
                        materialName
                    }
                }
            }",
            Variables = new
            {
                input
            }
        };
        return await _graphqlClient.SendMutationAsync<CreateProductResponseModel>(createProductMutation);
    }

    //GET PRODUCT BY ID
    
    public async Task<GraphQLResponse<GetProductResponseModel>> GetProductByIdAsync(string id)
    {
        var GetProductByIdQuery = new GraphQLRequest
        {
            Query = @"
            query ($id: String!) {
                getProductById(id: $id) {
                    id
                    title
                    brand
                    size
                    color
                    price
                    description
                    stockStatus
                    sku
                    ratings
                    productImage
                    categories {
                        categoryName
                        subCategories {
                            categoryName
                        }
                    }
                    materials {
                        materialName
                    }
                }
            }
            ",
            Variables = new { id }
        };
        return await _graphqlClient.SendQueryAsync<GetProductResponseModel>(GetProductByIdQuery);
    }

    //UPDATE PRODUCT
    public async Task<GraphQLResponse<ProductUpdateRequest>> UpdateProduct(ProductUpdateRequest input)
    {
        var updateProudctMutaion = new GraphQLRequest
        {
            Query = @"
            mutation ($input: ProductUpdateRequestInput!) {
                updateProduct(input: $input) {
                    id
                    title
                    brand
                    size
                    color
                    price
                    description
                    stockStatus
                    sku
                    ratings
                    productImage
                    categories {
                        categoryName
                        subCategories {
                            categoryName
                        }
                    }
                    materials {
                        materialName
                    }
                }
            }",
            Variables = new
            {
                input
            }
        };
        return await _graphqlClient.SendMutationAsync<ProductUpdateRequest>(updateProudctMutaion);
    }

    //DELETE PRODUCT
    public async Task DeleteProduct(string id)
    {
        var deleteProductMutation = new GraphQLRequest
        {
            Query = @"
                mutation ($id: String!) {
                    deleteProduct(id: $id)
                }
            ",
            Variables = new
            {
                id
            }
        };
        await _graphqlClient.SendMutationAsync<string>(deleteProductMutation);
    }
}
