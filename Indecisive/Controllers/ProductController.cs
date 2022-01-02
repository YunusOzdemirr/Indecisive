using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;
using Shared.Entities.ComplexTypes;

namespace Indecisive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllProducts(bool isActive = true, bool isDeleted = false, bool isAscending = true, int currentPage = 1, int pageSize = 20, OrderBy orderBy = OrderBy.Id)
        {
            var result = await _productService.GetAllAsync(isActive, isDeleted, isAscending, currentPage, pageSize, orderBy);
            return Ok(result);
        }
        [HttpPost("AddAsync")]
        public async Task<IActionResult> AddAsync(ProductAddDto productAddDto)
        {
            var result = await _productService.AddAsync(productAddDto);
            return Ok(result);
        }

        [HttpPost("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync(int productId)
        {
            var result = await _productService.DeleteAsync(productId);
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int productId)
        {
            var result = await _productService.GetByIdAsync(productId);
            return Ok(result);
        }
        [HttpPost("HardDeleteAsync")]
        public async Task<IActionResult> HardDeleteAsync(int productId)
        {
            var result = await _productService.HardDeleteAsync(productId);
            return Ok(result);
        }
        [HttpPost("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync(ProductUpdateDto productUpdateDto)
        {
            var result = await _productService.UpdateAsync(productUpdateDto);
            return Ok(result);
        }

        [HttpGet("GetAllWithoutPagingAsync")]
        public async Task<IActionResult> GetAllWithoutPagingAsync(bool isActive = true, bool isDeleted = false, bool isAscending = true, OrderBy orderBy = OrderBy.Id)
        {
            var result = await _productService.GetAllWithoutPageAsync(isActive, isDeleted, isAscending, orderBy);
            return Ok(result);
        }
    }
}