using AutoMapper;
using Data.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.Dtos.CompanyDtos;
using Microsoft.EntityFrameworkCore;
using Services.Abstract;
using Services.Utilities;
using Shared.Entities.ComplexTypes;
using Shared.Entities.Concrete;
using Shared.Utilities.Exceptions;
using Shared.Utilities.Results.Abstract;
using Shared.Utilities.Results.ComplexTypes;
using Shared.Utilities.Results.Concrete;

namespace Services.Concrete
{
    public class CompanyManager : ManagerBase, ICompanyService
    {
        public CompanyManager(IndecisiveContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<IResult> AddAsync(CompanyAddDto companyAddDto)
        {
            var isExist = DbContext.Companies.AsNoTracking().SingleOrDefault(a => a.Name == companyAddDto.Name);
            if (isExist is not null)
                throw new NotFoundException(Messages.General.ValidationError(), new Error("Bu Şirket Mevcut", "Name"));

            var company = Mapper.Map<Company>(companyAddDto);
            await DbContext.Companies.AddAsync(company);
            await DbContext.SaveChangesAsync();
            return new Result(ResultStatus.Succes, company);
        }

        public async Task<IResult> DeleteAsync(int companyId)
        {
            var company = await DbContext.Companies.SingleOrDefaultAsync(a => a.Id == companyId);
            if (company is null)
                throw new NotFoundException(Messages.General.ValidationError(), new Error("Böyle bir Şirket Bulunmamakta", "Id"));

            company.IsDeleted = true;
            company.IsActive = false;
            DbContext.Companies.Update(company);
            await DbContext.SaveChangesAsync();
            return new Result(ResultStatus.Succes, company);
        }

        public async Task<IResult> GetAll(bool? isActive, bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy)
        {
            IQueryable<Company> query = DbContext.Set<Company>().AsNoTracking();
            if (isActive.HasValue) query = query.Where(a => a.IsActive == isActive);
            if (isDeleted.HasValue) query = query.Where(a => a.IsDeleted == isDeleted);
            pageSize = pageSize > 100 ? 100 : pageSize;
            int TotalCount = query.Count();
            switch (orderBy)
            {
                case OrderBy.Id:
                    query = isAscending ? query.OrderBy(a => a.Id) : query.OrderByDescending(a => a.Id);
                    break;
                case OrderBy.Az:
                    query = isAscending ? query.OrderBy(a => a.Name) : query.OrderByDescending(a => a.Name);
                    break;
                default:
                    query = isAscending ? query.OrderBy(a => a.CreatedDate) : query.OrderByDescending(a => a.CreatedDate);
                    break;
            }
            return new Result(ResultStatus.Succes, new CompanyListDto
            {
                //Categories = await query.Skip((currentPage - 1) * pageSize).Take(pageSize).Select(a => Mapper.Map<Category>(a)).ToListAsync(),
                Companies = await query.Skip((currentPage - 1) * pageSize).Take(pageSize).Select(a => Mapper.Map<Company>(a)).ToListAsync(),
                PageSize = pageSize,
                CurrentPage = currentPage,
                IsAscending = isAscending,
                TotalCount = TotalCount
            });
        }

        public async Task<IResult> GetAllWithoutPageSize(bool? isActive, bool? isDeleted, bool isAscending, OrderBy orderBy)
        {

            IQueryable<Company> query = DbContext.Set<Company>().AsNoTracking();
            if (isActive.HasValue) query = query.Where(a => a.IsActive == isActive);
            if (isDeleted.HasValue) query = query.Where(a => a.IsDeleted == isDeleted);
            switch (orderBy)
            {
                case OrderBy.Id:
                    query = isAscending ? query.OrderBy(a => a.Id) : query.OrderByDescending(a => a.Id);
                    break;
                case OrderBy.Az:
                    query = isAscending ? query.OrderBy(a => a.Name) : query.OrderByDescending(a => a.Name);
                    break;
                case OrderBy.ModifiedDate:
                    query = isAscending ? query.OrderBy(a => a.ModifiedDate) : query.OrderByDescending(a => a.ModifiedDate);
                    break;
                default:
                    query = isAscending ? query.OrderBy(a => a.CreatedDate) : query.OrderByDescending(a => a.CreatedDate);
                    break;
            }
            return new Result(ResultStatus.Succes, new CompanyListDto
            {
                Companies = await query.Select(a => Mapper.Map<Company>(a)).ToListAsync(),
                IsAscending = isAscending,
                TotalCount = query.Count(),
            });
        }

        public async Task<IResult> GetByIdAsync(int companyId)
        {
            var company = await DbContext.Companies.AsNoTracking().SingleOrDefaultAsync(a => a.Id == companyId);
            if (company is null)
                throw new NotFoundException(Messages.General.ValidationError(), new Error("Böyle bir şirket bulunamadı", "Id"));

            return new Result(ResultStatus.Succes, company);
        }

        public async Task<IResult> HardDeleteAsync(int companyId)
        {
            var company = await DbContext.Companies.SingleOrDefaultAsync(a => a.Id == companyId);
            if (company is null)
                throw new NotFoundException(Messages.General.ValidationError(), new Error("Böyle bir şirket bulunamadı", "Id"));

            DbContext.Companies.Remove(company);
            await DbContext.SaveChangesAsync();
            return new Result(ResultStatus.Succes, true);
        }

        public async Task<IResult> UpdateAsync(CompanyUpdateDto companyUpdateDto)
        {
            var OldCompany = await DbContext.Companies.SingleOrDefaultAsync(a => a.Id == companyUpdateDto.Id);
            if (OldCompany is null)
                throw new NotFoundException(Messages.General.ValidationError(), new Error("Böyle bir şirket bulunamadı", "Id"));

            var company = Mapper.Map<CompanyUpdateDto, Company>(companyUpdateDto, OldCompany);
            company.ModifiedDate = DateTime.Now;
            DbContext.Companies.Update(company);
            await DbContext.SaveChangesAsync();
            return new Result(ResultStatus.Succes, company);
        }
    }
}

