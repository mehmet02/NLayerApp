using NLayer.Core.DTOs;
using NLayer.Core.Model;

namespace NLayer.Core.Services;

public interface IProductService:IService<Product>
{
    Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategory();
    Task<List<ProductWithCategoryDto>> GetProductsWithCategories();
}