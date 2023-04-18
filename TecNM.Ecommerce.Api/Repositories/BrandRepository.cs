using Dapper;
using Dapper.Contrib.Extensions;
using TecNM.Ecommerce.Api.DataAccess.Interfaces;
using TecNM.Ecommerce.Api.Repositories.Interfaces;
using TecNM.Ecommerce.Core.Entities;

namespace TecNM.Ecommerce.Api.Repositories;

public class BrandRepository : IBrandRepository
{
    private readonly IDbContext _dbContext;

    public BrandRepository(IDbContext context)
    {
        _dbContext = context;
    }
    
    public async Task<Brand> SaveAsync(Brand brand)
    {
        brand.Id = await _dbContext.Connection.InsertAsync(brand);

        return brand;
    }

    public async Task<Brand> UpdateAsync(Brand brand)
    {
        await _dbContext.Connection.UpdateAsync(brand);
        return brand;
    }

    public async Task<List<Brand>> GetAllAsync()
    {
        const string sql = "SELECT * FROM Brand WHERE IsDeleted = 0";

        var categories = await _dbContext.Connection.QueryAsync<Brand>(sql);

        return categories.ToList();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var category = await GetById(id);

        if (category == null)
        {
            return false;
        }

        category.IsDeleted = true;

        return await _dbContext.Connection.UpdateAsync(category);
    }

    public async Task<Brand> GetById(int id)
    {
        var category = await _dbContext.Connection.GetAsync<Brand>(id);

        if (category == null)
            return null;

        return category.IsDeleted == true ? null : category;
    }
}