using Microsoft.AspNetCore.Mvc.RazorPages;
using TecNM.Ecommerce.Core.Dto;

namespace TecNM.Ecommerce.WebSite.Pages.ProductCategory;

public class ListModel : PageModel
{
    public List<ProductCategoryDto> ProductCategories { get; set; }

    public ListModel()
    {
        ProductCategories = new List<ProductCategoryDto>
        {
            new ProductCategoryDto { Id = 1, Name = "Fernando", Description = "Fer" },
            new ProductCategoryDto { Id = 2, Name = "Adolfo", Description = "L" },
            new ProductCategoryDto { Id = 3, Name = "Sr. Hollywood", Description = "Excelente" }
        };
    }
    
    public void OnGet()
    {
        
    }
}