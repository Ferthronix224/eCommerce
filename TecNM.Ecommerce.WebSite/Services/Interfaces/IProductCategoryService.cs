using TecNM.Ecommerce.Core.Dto;
using TecNM.Ecommerce.Core.Http;

namespace TecNM.Ecommerce.WebSite.Services.Interfaces;

public interface IProductCategoryService
{
    Task<Response<List<ProductCategoryDto>>> GetAllAsync();
    
    Task<Response<ProductCategoryDto>> GetById(int id);
    
    Task<Response<ProductCategoryDto>> SaveAsync(ProductCategoryDto productCategory);
    
    Task<Response<ProductCategoryDto>> UpdateAsync(ProductCategoryDto productCategory);

    Task<Response<bool>> DeleteAsync(int id);
}