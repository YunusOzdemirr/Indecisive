using Entities.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;
using Shared.Entities.ComplexTypes;
using Shared.Entities.Concrete;

namespace Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync(bool isActive = true, bool isDeleted = false, bool isAscending = true, int currentPage = 1, int pageSize = 20, OrderBy orderBy = 0, bool includeCategoryAndProduct = false)
        {
            var result = await _categoryService.GetAllAsync(isActive, isDeleted, isAscending, currentPage, pageSize, orderBy, includeCategoryAndProduct);
            return Ok(result);
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int Id, bool includeCategoryAndProduct)
        {
            var result = await _categoryService.GetByIdAsync(Id, includeCategoryAndProduct);
            return Ok(result);
        }

        [HttpPost("AddAsync")]
        public async Task<IActionResult> AddAsync(CategoryAddDto categoryAddDto)
        {
            var result = await _categoryService.AddAsync(categoryAddDto);
            return Ok(result);
        }
        [HttpPost("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync(CategoryUpdateDto categoryUpdateDto)
        {
            var result = await _categoryService.UpdateAsync(categoryUpdateDto);
            return Ok(result);
        }

        [HttpPost("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            var result = await _categoryService.DeleteAsync(Id);
            return Ok(result);
        }
        [HttpGet("GetAllWithoutPagingAsync")]
        public async Task<IActionResult> GetAllWithoutPagingAsync(bool isActive = true, bool isDeleted = false, bool isAscending = true, OrderBy orderBy = OrderBy.CreatedDate, bool includeCategoryAndProduct = false)
        {
            var result = await _categoryService.GetAllWithoutPagingAsync(isActive, isDeleted, isAscending, orderBy, includeCategoryAndProduct);
            return Ok(result);
        }
    }
}