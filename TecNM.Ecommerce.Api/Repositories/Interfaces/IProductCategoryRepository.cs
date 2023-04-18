using TecNM.Ecommerce.Core.Entities;

namespace TecNM.Ecommerce.Api.Repositories.Interfaces;

public interface IProductCategoryRepository
{
    //Metodo para guardar categorias
    Task<ProductCategory> SaveAsync(ProductCategory category);
    
    //Metodo para actualizar las categorias de productos
    Task<ProductCategory> UpdateAsync(ProductCategory category);
    
    //Metodo para retornar una lista de categorias
    Task<List<ProductCategory>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias que borrara
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener una categoria por id
    Task<ProductCategory> GetById(int id);
}