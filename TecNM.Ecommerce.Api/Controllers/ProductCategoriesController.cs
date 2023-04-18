using Microsoft.AspNetCore.Mvc;
using TecNM.Ecommerce.Api.Services.Interfaces;
using TecNM.Ecommerce.Core.Dto;
using TecNM.Ecommerce.Core.Http;

namespace TecNM.Ecommerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductCategoriesController : ControllerBase
{
    private readonly IProductCatergoryService _productCatergoryService;
    
    public ProductCategoriesController(IProductCatergoryService productCategoryService)
    {
        _productCatergoryService = productCategoryService;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<ProductCategoryDto>>>> GetAll()
    {
        var response = new Response<List<ProductCategoryDto>>
        {
            Data = await _productCatergoryService.GetAllAsync()
        };
        
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<ActionResult<Response<ProductCategoryDto>>>Post([FromBody] ProductCategoryDto categoryDto)
    {
        var response = new Response<ProductCategoryDto>
        {
            Data = await _productCatergoryService.SaveAsync(categoryDto)
        };

        return Created($"/api/[controller]/{response.Data.Id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<ProductCategoryDto>>> GetById(int id)
    {
        var response = new Response<ProductCategoryDto>();
        if (!await _productCatergoryService.ProductCategoryExist(id))
        {
            response.Errors.Add("No hay no existe");
            return NotFound(response);
        }

        response.Data = await _productCatergoryService.GetById(id);
        return Ok(response);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<ProductCategoryDto>>> Update([FromBody] ProductCategoryDto categoryDto){
        var response = new Response<ProductCategoryDto>();
        if (!await _productCatergoryService.ProductCategoryExist(categoryDto.Id))
        {
            response.Errors.Add("No hay no existe");
            return NotFound(response);
        }

        response.Data = await _productCatergoryService.UpdateAsync(categoryDto);

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
        var result = await _productCatergoryService.DeleteAsync(id);
        response.Data = result;
        return Ok(response);
    }
    
}