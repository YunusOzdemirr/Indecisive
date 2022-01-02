using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Dtos.ProductDtos;
using Shared.Entities.ComplexTypes;
using Shared.Utilities.Results.Abstract;

namespace Services.Abstract
{
    public interface IProductService
    {
        public Task<IResult> AddAsync(ProductAddDto productAddDto);
        public Task<IResult> UpdateAsync(ProductUpdateDto productUpdateDto);
        public Task<IResult> GetAllAsync(bool? isActive, bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy);
        public Task<IResult> GetAllWithoutPageAsync(bool? isActive, bool? isDeleted, bool isAscending, OrderBy orderBy);
        public Task<IResult> DeleteAsync(int productId);
        public Task<IResult> HardDeleteAsync(int productId);
        public Task<IResult> GetByIdAsync(int productId);
    }
}