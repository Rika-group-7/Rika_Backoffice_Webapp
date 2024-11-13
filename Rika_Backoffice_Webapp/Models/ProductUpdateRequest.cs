using System.ComponentModel.DataAnnotations;

namespace Rika_Backoffice_Webapp.Models;

public class ProductUpdateRequest
{
    public string? Id { get; set; }

    [Required(ErrorMessage = "Title is mandatory")]
    [MinLength(2)]
    public string? Title { get; set; }

    [Required(ErrorMessage = "Brand is mandatory")]
    [MinLength(2)]
    public string? Brand { get; set; }

    [Required(ErrorMessage = "Size is mandatory")]
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

    public List<CategoryUpdateRequest>? Categories { get; set; } = [];
    public List<MaterialUpdateRequest>? Materials { get; set; } = [];
}

public class CategoryUpdateRequest
{
    public string? CategoryName { get; set; }
    public List<CategoryUpdateRequest>? SubCategories { get; set; } = [];
}
public class MaterialUpdateRequest
{
    public string? MaterialName { get; set; }
}