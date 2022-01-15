using System;
using System.Threading.Tasks;
using Entities.Dtos.CompanyDtos;
using Shared.Entities.ComplexTypes;
using Shared.Utilities.Results.Abstract;

namespace Services.Abstract
{
    public interface ICompanyService
    {
        public Task<IResult> AddAsync(CompanyAddDto companyAddDto);
        public Task<IResult> GetByIdAsync(int companyId);
        public Task<IResult> GetAll(bool? isActive, bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy);
        public Task<IResult> GetAllWithoutPageSize(bool? isActive, bool? isDeleted, bool isAscending, OrderBy orderBy);
        public Task<IResult> UpdateAsync(CompanyUpdateDto companyUpdateDto);
        public Task<IResult> DeleteAsync(int companyId);
        public Task<IResult> HardDeleteAsync(int companyId);
    }
}

