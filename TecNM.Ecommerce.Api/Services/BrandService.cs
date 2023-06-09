﻿using TecNM.Ecommerce.Api.Repositories.Interfaces;
using TecNM.Ecommerce.Api.Services.Interfaces;
using TecNM.Ecommerce.Core.Dto;
using TecNM.Ecommerce.Core.Entities;

namespace TecNM.Ecommerce.Api.Services;

public class BrandService : IBrandService
{
    private readonly IBrandRepository _brandRepository;

    public BrandService(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }
    
    public async Task<BrandDto> SaveAsync(BrandDto brandDto)
    {
        var brand = new Brand()
        {
            Name = brandDto.Name,
            Description = brandDto.Description,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdateDate = DateTime.Now
        };
        
        brand = await _brandRepository.SaveAsync(brand);
        brandDto.Id = brand.Id;

        return brandDto;
    }

    public async Task<BrandDto> UpdateAsync(BrandDto brandDto)
    {
        var brand = await _brandRepository.GetById(brandDto.Id);

        if (brand == null)
            throw new Exception("Product Category Not Found");
        
        brand.Name = brandDto.Name;
        brand.Description = brandDto.Description;
        brand.UpdatedBy = "";
        brand.UpdateDate = DateTime.Now;
        
        await _brandRepository.UpdateAsync(brand);
        
        return brandDto;
    }

    public async Task<List<BrandDto>> GetAllAsync()
    {
        var categories = await _brandRepository.GetAllAsync();
        var categoriesDto = categories.Select(c => new BrandDto(c)).ToList();
        
        return categoriesDto;
    }

    public async Task<bool> ProductCategoryExist(int id)
    {
        var category = await _brandRepository.GetById(id);
        return (category != null);
    }

    public async Task<BrandDto> GetById(int id)
    {
        var category = await _brandRepository.GetById(id);
        if (category == null)
            throw new Exception("Product Category Not Found");
        var categoryDto = new BrandDto(category);
        return categoryDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _brandRepository.DeleteAsync(id);
    }
}