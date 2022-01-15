using Entities.Dtos.CategoryAndProductDtos;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;
using Shared.Entities.ComplexTypes;

namespace Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryAndProductsController : ControllerBase
    {
        ICategoryAndProductService _categoryAndProductService;
        public CategoryAndProductsController(ICategoryAndProductService categoryAndProductService)
        {
            _categoryAndProductService = categoryAndProductService;
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync(bool isAscending = true, OrderBy orderBy = 0, bool includeCategory = false, bool includeProduct = false)
        {
            var result = await _categoryAndProductService.GetAllAsync(isAscending, orderBy, includeCategory, includeProduct);
            return Ok(result);
        }
        [HttpPost("AddAsync")]
        public async Task<IActionResult> AddAsync(CategoryAndProductAddDto categoryAndProductAddDto)
        {
            var result = await _categoryAndProductService.AddAsync(categoryAndProductAddDto);
            return Ok(result);
        }
        [HttpGet("GetProductsByCategoryId")]
        public async Task<IActionResult> GetProductsByCategoryId(int categoryId)
        {
            var result = await _categoryAndProductService.GetProductByCategoryId(categoryId);
            return Ok(result);
        }
        [HttpGet("GetCategoriesByProductId")]
        public async Task<IActionResult> GetCategoriesByProductId(int productId)
        {
            var result = await _categoryAndProductService.GetCategoryByProductId(productId);
            return Ok(result);
        }
        [HttpPost("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync(int categoryId, int productId)
        {
            var result = await _categoryAndProductService.DeleteAsync(categoryId, productId);
            return Ok(result);
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int categoryId, int productId)
        {
            var result = await _categoryAndProductService.GetById(categoryId, productId);
            return Ok(result);
        }
    }
}