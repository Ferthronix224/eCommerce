using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TecNM.Ecommerce.Core.Dto;
using TecNM.Ecommerce.Core.Http;
using TecNM.Ecommerce.WebSite.Services.Interfaces;

namespace TecNM.Ecommerce.WebSite.Pages.ProductCategory;

//Tipo Razor Page
public class Edit : PageModel
{
    [BindProperty] public ProductCategoryDto ProductCategory { get; set; }

    public List<string> Errors { get; set; } = new List<string>();
    private readonly IProductCategoryService _service;

    public Edit(IProductCategoryService service)
    {
        _service = service;
    }
    
    public async Task<IActionResult> OnGet(int? id)
    {
        ProductCategory = new ProductCategoryDto();
        if (id.HasValue)
        {
            //Obtener información del servicio (API)
            var response = await _service.GetById(id.Value);
            ProductCategory = response.Data;
        }

        if (ProductCategory == null)
        {
            return RedirectToPage("/Error");
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        Response<ProductCategoryDto> response;

        if (ProductCategory.Id > 0)
        {
            //Actualizar
            response = await _service.UpdateAsync(ProductCategory);
        }
        else
        {
            //Insert
            response = await _service.SaveAsync(ProductCategory);
        }

        ProductCategory = response.Data;

        return RedirectToPage("/List");
    }
}