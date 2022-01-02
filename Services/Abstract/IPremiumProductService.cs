using Entities.Dtos.PremiumProductDtos;
using Shared.Entities.ComplexTypes;
using Shared.Utilities.Results.Abstract;

namespace Services.Abstract
{
    public interface IPremiumProductService
    {
        public Task<IResult> AddAsync(PremiumProductAddDto premiumProductAddDto);
        public Task<IResult> GetAllAsync(bool? isActive, bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy);
        public Task<IResult> GetAllWithoutPageAsync(bool? isActive, bool? isDeleted, bool isAscending, OrderBy orderBy);
        public Task<IResult> GetByIdAsync(int premiumProductId, int companyId);
        public Task<IResult> DeleteAsync(int premiumProductId, int companyId);
        public Task<IResult> HardDeleteAsync(int premiumProductId, int companyId);
        public Task<IResult> UpdateAsync(PremiumProductUpdateDto premiumProductUpdateDto);
        public Task<IResult> GetAllProductByCompanyId(int companyId);
    }
}