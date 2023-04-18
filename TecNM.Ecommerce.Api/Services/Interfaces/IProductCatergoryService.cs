using TecNM.Ecommerce.Core.Dto;

namespace TecNM.Ecommerce.Api.Services.Interfaces;

public interface IProductCatergoryService
{
    //Metodo para guardar categorias
    Task<ProductCategoryDto> SaveAsync(ProductCategoryDto category);
    
    //Metodo para actualizar las categorias de productos
    Task<ProductCategoryDto> UpdateAsync(ProductCategoryDto category);
    
    //Metodo para retornar una lista de categorias
    Task<List<ProductCategoryDto>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias que borrara
    Task<bool> ProductCategoryExist(int id);
    
    //Metodo para obtener una categoria por id
    Task<ProductCategoryDto> GetById(int id);

    Task<bool> DeleteAsync(int id);
}