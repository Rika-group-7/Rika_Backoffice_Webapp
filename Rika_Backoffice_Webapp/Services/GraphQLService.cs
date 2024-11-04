using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Rika_Backoffice_Webapp.Models;

namespace Rika_Backoffice_Webapp.Services;

public class GraphQLService
{
    private readonly GraphQLHttpClient _graphqlClient =
    new GraphQLHttpClient("https://productprovider-rika.azurewebsites.net/api/graphql?code=Da4aZa9Xnh8jmwu-Srgxk8wI7NpUBsKbMxQa9hoS0kp9AzFueYwEOg%3D%3D", new NewtonsoftJsonSerializer());


    //GET ALL PRODUCTS
    private readonly GraphQLRequest _getProducts = new GraphQLRequest
    {
        Query = @"
            query getProducts {
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
        ",
        OperationName = "GetProducts"
    };

    private readonly GraphQLRequest _getProductById = new GraphQLRequest
    {
        Query = @"
            query ($id: ID!) {
                getProductsById(id: $id) {
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
        OperationName = "GetProductById"
    };

    public async Task<GraphQLResponse<GetAllProductsRequest>> GetProducts()
    {
        var fetch = await _graphqlClient.SendQueryAsync<GetAllProductsRequest>(_getProducts);

        return fetch;
    }

    //CREATE PRODUCT
    public async Task CreateProduct(ProductCreateRequest input)
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
            OperationName = "CreateProduct",
            Variables = new
            {
                input
            }
        };
        await _graphqlClient.SendMutationAsync<ProductCreateRequest>(createProductMutation);
    }

    public async Task<GraphQLResponse<Product>> GetProductById(string id)
    {
        var fetch = await _graphqlClient.SendQueryAsync<Product>(_getProductById);

        return fetch;
    }

    public async Task UpdateProduct(ProductUpdateRequest input)
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
            OperationName = "UpdateProduct",
            Variables = new
            {
                input
            }
        };
        await _graphqlClient.SendMutationAsync<ProductUpdateRequest>(updateProudctMutaion);
    }

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
