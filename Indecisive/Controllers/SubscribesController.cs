using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Dtos.SubscribeDtos;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;
using Shared.Entities.ComplexTypes;

namespace Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribesController : ControllerBase
    {
        private readonly ISubscribeService _subscribeService;

        public SubscribesController(ISubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
        }

        [HttpPost("AddAsync")]
        public async Task<IActionResult> AddAsync(SubscribeAddDto subscribeAddDto)
        {
            var result = await _subscribeService.AddAsync(subscribeAddDto);
            return Ok(result);
        }
        [HttpPost("UpateAsync")]
        public async Task<IActionResult> UpdateAsync(SubscribeUpdateDto subscribeUpdateDto)
        {
            var result = await _subscribeService.UpdateAsync(subscribeUpdateDto);
            return Ok(result);
        }
        [HttpPost("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            var result = await _subscribeService.DeleteAsync(Id);
            return Ok(result);
        }
        [HttpPost("HardDeleteAsync")]
        public async Task<IActionResult> HardDeleteAsync(int Id)
        {
            var result = await _subscribeService.HardDeleteAsync(Id);
            return Ok(result);
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync(bool isActive = true, bool isDeleted = false, bool isAscending = true, int currentPage = 1, int pageSize = 20, OrderBy orderBy = 0)
        {
            var result = await _subscribeService.GetAllAsync(isActive, isDeleted, isAscending, currentPage, pageSize, orderBy);
            return Ok(result);
        }

        [HttpPost("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int Id)
        {
            var result = await _subscribeService.GetByIdAsync(Id);
            return Ok(result);
        }


    }
}