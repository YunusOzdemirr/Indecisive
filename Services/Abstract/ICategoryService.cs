using System;
using Entities.Concrete;
using Shared.Entities.ComplexTypes;
using Shared.Utilities.Results.Abstract;

namespace Services.Abstract
{
    public interface ICategoryService
    {
        public Task<IResult> AddAsync(Category category);
        public Task<IResult> DeleteAsync(int categoryId);
        public Task<IResult> GetAllAsync(bool? isActive, bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy, bool includeCategoryAndProduct);
        public Task<IResult> GetAllWithoutPagingAsync(bool? isActive, bool? isDeleted, bool isAscending, OrderBy orderBy)
        public Task<IResult> GetByIdAsync(int categoryId);
        public Task<IResult> UpdateAsync(Category category);
    }
}

