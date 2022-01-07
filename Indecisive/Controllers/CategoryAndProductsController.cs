using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IActionResult> GetAllAsync(bool isAscending = true, OrderBy orderBy = 0)
        {
            var result = await _categoryAndProductService.GetAllAsync(isAscending, orderBy);
            return Ok(result);
        }
        [HttpPost("AddAsync")]
        public async Task<IActionResult> AddAsync(CategoryAndProductAddDto categoryAndProductAddDto)
        {
            var result = await _categoryAndProductService.AddAsync(categoryAndProductAddDto);
            return Ok(result);
        }
        [HttpPost("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync(CategoryAndProductUpdateDto categoryAndProductUpdateDto)
        {
            var result = await _categoryAndProductService.UpdateAsync(categoryAndProductUpdateDto);
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