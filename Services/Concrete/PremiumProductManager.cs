using System.Linq;
using AutoMapper;
using Data.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.Dtos.PremiumProductDtos;
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
    public class PremiumProductManager : ManagerBase, IPremiumProductService
    {
        public PremiumProductManager(IndecisiveContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<IResult> AddAsync(PremiumProductAddDto premiumProductAddDto)
        {
            var IsExistProduct = await DbContext.PremiumProducts.AsNoTracking().SingleOrDefaultAsync(a => a.Product.Id == premiumProductAddDto.ProductId && a.CompanyId == premiumProductAddDto.CompanyId);
            if (IsExistProduct is not null)
                throw new ExistArgumentException(Messages.General.IsExistArgument(), new Error("Name && CompanyId"));

            var premiumProduct = Mapper.Map<PremiumProduct>(premiumProductAddDto);
            await DbContext.PremiumProducts.AddAsync(premiumProduct);
            await DbContext.SaveChangesAsync();
            return new Result(ResultStatus.Succes, premiumProduct);
        }

        public async Task<IResult> DeleteAsync(int premiumProductId, int companyId)
        {
            var premiumProduct = await DbContext.PremiumProducts.SingleOrDefaultAsync(a => a.ProductId == premiumProductId && a.CompanyId == companyId);
            if (premiumProduct is null)
                throw new NotFoundException(Messages.General.ValidationError(), new Error(Messages.General.NotFoundArgument(), "Id"));
            premiumProduct.IsActive = false;
            premiumProduct.IsDeleted = true;
            DbContext.PremiumProducts.Update(premiumProduct);
            await DbContext.SaveChangesAsync();
            return new Result(ResultStatus.Succes, premiumProduct, "Ürün başarıyla silindi");
        }

        public async Task<IResult> GetAllAsync(bool? isActive, bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy)
        {
            IQueryable<PremiumProduct> query = DbContext.Set<PremiumProduct>().AsNoTracking();
            if (isActive.HasValue) query = query.Where(a => a.IsActive == isActive);
            if (isDeleted.HasValue) query = query.Where(a => a.IsDeleted == isDeleted);
            pageSize = pageSize > 100 ? 100 : pageSize;
            switch (orderBy)
            {
                case OrderBy.Id:
                    query = isAscending ? query.OrderBy(a => a.CompanyId) : query.OrderByDescending(a => a.CompanyId);
                    break;
                case OrderBy.Az:
                    query = isAscending ? query.OrderBy(a => a.Product.Name) : query.OrderByDescending(a => a.Product.Name);
                    break;
                case OrderBy.ModifiedDate:
                    query = isAscending ? query.OrderBy(a => a.ModifiedDate) : query.OrderByDescending(a => a.ModifiedDate);
                    break;
                default:
                    query = isAscending ? query.OrderBy(a => a.CreatedDate) : query.OrderByDescending(a => a.CreatedDate);
                    break;
            }
            return new Result(ResultStatus.Succes, new PremiumProductListDto
            {
                PremiumProducts = await query.Skip((currentPage - 1) * pageSize).Take(pageSize).Select(a => Mapper.Map<PremiumProduct>(a)).ToListAsync(),
                TotalCount = await query.CountAsync(),
                PageSize = pageSize,
                CurrentPage = currentPage,
                IsAscending = isAscending
            });

        }

        public async Task<IResult> GetAllProductByCompanyId(int companyId)
        {
            var products = DbContext.PremiumProducts.Where(a => a.CompanyId == companyId);
            if (products is null)
                throw new NotFoundException(Messages.General.ValidationError(), new Error(Messages.General.NotFoundArgument(), "Id"));
            return new Result(ResultStatus.Succes, await Task.FromResult(products));
        }

        public async Task<IResult> GetAllWithoutPageAsync(bool? isActive, bool? isDeleted, bool isAscending, OrderBy orderBy)
        {
            IQueryable<PremiumProduct> query = DbContext.Set<PremiumProduct>().AsNoTracking();
            if (isActive.HasValue) query = query.Where(a => a.IsActive == isActive);
            if (isDeleted.HasValue) query = query.Where(a => a.IsDeleted == isDeleted);
            switch (orderBy)
            {
                case OrderBy.Id:
                    query = isAscending ? query.OrderBy(a => a.CompanyId) : query.OrderByDescending(a => a.CompanyId);
                    break;
                case OrderBy.Az:
                    query = isAscending ? query.OrderBy(a => a.Product.Name) : query.OrderByDescending(a => a.Product.Name);
                    break;
                case OrderBy.ModifiedDate:
                    query = isAscending ? query.OrderBy(a => a.ModifiedDate) : query.OrderByDescending(a => a.ModifiedDate);
                    break;
                default:
                    query = isAscending ? query.OrderBy(a => a.CreatedDate) : query.OrderByDescending(a => a.CreatedDate);
                    break;
            }
            return new Result(ResultStatus.Succes, new PremiumProductListDto
            {
                PremiumProducts = await query.Select(a => Mapper.Map<PremiumProduct>(a)).ToListAsync(),
                TotalCount = query.Count(),
                IsAscending = isAscending
            });
        }

        public async Task<IResult> GetByIdAsync(int premiumProductId, int companyId)
        {
            var premiumProduct = await DbContext.PremiumProducts.AsNoTracking().SingleOrDefaultAsync(a => a.ProductId == premiumProductId && a.CompanyId == companyId);
            if (premiumProduct is null)
                throw new NotFoundException(Messages.General.ValidationError(), new Error(Messages.General.NotFoundArgument(), "Id && CompanyId"));
            return new Result(ResultStatus.Succes, premiumProduct);
        }

        public async Task<IResult> HardDeleteAsync(int premiumProductId, int companyId)
        {
            var premiumProduct = await DbContext.PremiumProducts.AsNoTracking().SingleOrDefaultAsync(a => a.ProductId == premiumProductId && a.CompanyId == companyId);
            if (premiumProduct is null)
                throw new NotFoundException(Messages.General.ValidationError(), new Error(Messages.General.NotFoundArgument(), "Id && CompanyId"));

            DbContext.PremiumProducts.Remove(premiumProduct);
            await DbContext.SaveChangesAsync();
            return new Result(ResultStatus.Succes, premiumProduct, "Ürün başarıyla kalıcı olarak silindi");
        }

        public async Task<IResult> UpdateAsync(PremiumProductUpdateDto premiumProductUpdateDto)
        {
            var oldPremiumProduct = await DbContext.PremiumProducts.AsNoTracking().SingleOrDefaultAsync(a => a.ProductId == premiumProductUpdateDto.ProductId && a.CompanyId == premiumProductUpdateDto.CompanyId);
            if (oldPremiumProduct is null)
                throw new NotFoundException(Messages.General.ValidationError(), new Error(Messages.General.NotFoundArgument(), "Id && CompanyId"));

            var newPremiumProduct = Mapper.Map<PremiumProductUpdateDto, PremiumProduct>(premiumProductUpdateDto, oldPremiumProduct);
            DbContext.PremiumProducts.Update(newPremiumProduct);
            await DbContext.SaveChangesAsync();
            return new Result(ResultStatus.Succes, newPremiumProduct);
        }
    }
}