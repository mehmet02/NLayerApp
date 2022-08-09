using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    public class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        // api/categories/GetSingleCategoryByIdWithProductAsync/2
        //[HttpGet("[action]")]
        //public async Task<IActionResult> GetSingleCategoryByIdWithProductAsync(int categoryid)
        //{
        //    return CrateActionResult(await _categoryService.GetSingleCategoryByIdWithProductAsync(categoryid));
        //}
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());
            return CrateActionResult(CustomResponseDto<List<CategoryDto>>.Success(200, categoriesDto));
        }


        // api/categories/GetSingleCategoryByIdWithProducts/2
        [HttpGet("[action]/{categoryId}")]
        public async Task<IActionResult> GetSingleCategoryByIdWithProducts(int categoryId)
        {

            return CrateActionResult(await _categoryService.GetSingleCategoryByIdWithProductAsync(categoryId));

        }
    }
}
