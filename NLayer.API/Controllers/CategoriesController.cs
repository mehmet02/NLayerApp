using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    public class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        // api/categories/GetSingleCategoryByIdWithProductAsync/2
        [HttpGet("[action]")]
        public async Task<IActionResult> GetSingleCategoryByIdWithProductAsync(int categoryid)
        {
            return CrateActionResult(await _categoryService.GetSingleCategoryByIdWithProductAsync(categoryid));
        }
    }
}
