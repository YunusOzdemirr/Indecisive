using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

    }
}