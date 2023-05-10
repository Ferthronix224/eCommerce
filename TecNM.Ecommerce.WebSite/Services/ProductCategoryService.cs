using Newtonsoft.Json;
using TecNM.Ecommerce.Core.Dto;
using TecNM.Ecommerce.Core.Http;
using TecNM.Ecommerce.WebSite.Services.Interfaces;

namespace TecNM.Ecommerce.WebSite.Services;

public class ProductCategoryService : IProductCategoryService
{
    //activar certificado en cmd: dotnet dev-certs https --trust
    //utilizar direccion swagger
    private readonly string _baseurl = "https://localhost:7000/";
    private readonly string _endpoint = "api/ProductCategories";

    public ProductCategoryService()
    {
        
    }
    
    public async Task<Response<List<ProductCategoryDto>>> GetAllAsync()
    {
        var url = $"{_baseurl}{_endpoint}";
        var client = new HttpClient();
        var res = await client.GetAsync(url);
        var json = await res.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<Response<List<ProductCategoryDto>>>(json);
        return response;
    }

    public async Task<Response<ProductCategoryDto>> GetById(int id)
    {
        var url = $"{_baseurl}{_endpoint}/{id}";
        var client = new HttpClient();
        var res = await client.GetAsync(url);
        var json = await res.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<ProductCategoryDto>>(json);

        return response;
    }

    public async Task<Response<ProductCategoryDto>> SaveAsync(ProductCategoryDto productCategory)
    {
        var url = $"{_baseurl}{_endpoint}";
        var jsonRequest = JsonConvert.SerializeObject(productCategory);
        var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
        var client = new HttpClient();
        var res = await client.PostAsync(url, content);
        var json = await res.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<ProductCategoryDto>>(json);

        return response;
    }

    public async Task<Response<ProductCategoryDto>> UpdateAsync(ProductCategoryDto productCategory)
    {
        var url = $"{_baseurl}{_endpoint}";
        var jsonRequest = JsonConvert.SerializeObject(productCategory);
        var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
        var client = new HttpClient();
        var res = await client.PutAsync(url, content);
        var json = await res.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<ProductCategoryDto>>(json);

        return response;
    }

    public async Task<Response<bool>> DeleteAsync(int id)
    {
        var url = $"{_baseurl}{_endpoint}/{id}";
        var client = new HttpClient();
        var res = await client.DeleteAsync(url);
        var json = await res.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<bool>>(json);

        return response;
    }
}