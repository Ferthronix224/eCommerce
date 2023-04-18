using TecNM.Ecommerce.Core.Dto;

namespace TecNM.Ecommerce.Api.Services.Interfaces;

public interface IBrandService
{
    //Metodo para guardar categorias
    Task<BrandDto> SaveAsync(BrandDto brandDto);
    
    //Metodo para actualizar las categorias de productos
    Task<BrandDto> UpdateAsync(BrandDto brandDto);
    
    //Metodo para retornar una lista de categorias
    Task<List<BrandDto>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias que borrara
    Task<bool> ProductCategoryExist(int id);
    
    //Metodo para obtener una categoria por id
    Task<BrandDto> GetById(int id);

    Task<bool> DeleteAsync(int id);
}