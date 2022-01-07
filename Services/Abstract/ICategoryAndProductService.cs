using Entities.Concrete;
using Entities.Dtos.CategoryAndProductDtos;
using Shared.Entities.ComplexTypes;
using Shared.Entities.Concrete;
using Shared.Utilities.Results.Abstract;

namespace Services.Abstract
{
    public interface ICategoryAndProductService
    {
        Task<IResult> AddAsync(CategoryAndProductAddDto categoryAndProductAddDto);
        Task<IResult> GetAllAsync(bool isAscending, OrderBy orderBy, bool includeCategory, bool includeProduct);
        Task<IResult> GetProductByCategoryId(int categoryId);
        Task<IResult> GetCategoryByProductId(int productId);
        Task<IResult> GetById(int categoryId, int productId);
        Task<IResult> DeleteAsync(int categoryId, int productId);
    }
}