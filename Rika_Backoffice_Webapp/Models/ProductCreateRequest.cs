using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Rika_Backoffice_Webapp.Models;

public class ProductCreateRequest
{
    public string? Id { get; set; }

    [Required(ErrorMessage = "Title is mandatory")]
    [MinLength(2)]
    public string? Title { get; set; }

    [Required(ErrorMessage = "Brand is mandatory")]
    [MinLength(2)]
    public string? Brand { get; set; }

    [Required(ErrorMessage = "Size is mandatory")]
    [MinLength(2)]
    public string? Size { get; set; }

    [Required(ErrorMessage = "Color is mandatory")]
    [MinLength(2)]
    public string? Color { get; set; }

    [Required(ErrorMessage = "Price is mandatory")]
    public decimal? Price { get; set; }

    [Required(ErrorMessage = "Description is mandatory")]
    [MinLength(2)]
    public string? Description { get; set; }

    public bool StockStatus { get; set; }

    [Required(ErrorMessage = "SKU is mandatory")]
    [MinLength(2)]
    public string? SKU { get; set; }

    [Required(ErrorMessage = "Rating is mandatory")]
    public decimal? Ratings { get; set; }

    [Required(ErrorMessage = "Product image is mandatory")]
    public string? ProductImage { get; set; }

    public List<CategoryCreateRequest>? Categories { get; set; } = new();
    public List<MaterialCreateRequest>? Materials { get; set; } = new();

    public class CategoryCreateRequest
    {
        public string? CategoryName { get; set; }
        public List<CategoryCreateRequest>? SubCategories { get; set; } = new();
    }

    public class MaterialCreateRequest
    {
        public string? MaterialName { get; set; }
    }
}