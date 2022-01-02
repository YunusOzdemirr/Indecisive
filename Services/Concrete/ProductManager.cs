using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.Dtos.ProductDtos;
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
    public class ProductManager : ManagerBase, IProductService
    {
        public ProductManager(IndecisiveContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<IResult> AddAsync(ProductAddDto productAddDto)
        {
            var isExistProduct = await DbContext.Products.AsNoTracking().SingleOrDefaultAsync(a => a.Name == productAddDto.Name);
            if (isExistProduct is not null)
                throw new ExistArgumentException(Messages.General.ValidationError(), new Error("Bu ürün zaten mevcut", "Name"));

            var product = Mapper.Map<Product>(productAddDto);
            await DbContext.Products.AddAsync(product);
            await DbContext.SaveChangesAsync();
            return new Result(ResultStatus.Succes, product);
        }

        public async Task<IResult> DeleteAsync(int productId)
        {
            var product = await DbContext.Products.AsNoTracking().SingleOrDefaultAsync(a => a.Id == productId);
            if (product is null)
                throw new NotFoundException(Messages.General.ValidationError(), new Error("Böyle bir ürün bulunmamakta", "Id"));
            product.IsActive = false;
            product.IsDeleted = true;
            DbContext.Products.Update(product);
            await DbContext.SaveChangesAsync();
            return new Result(ResultStatus.Succes, product, "Ürün başarıyla silindi");
        }

        public async Task<IResult> GetAllAsync(bool? isActive, bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy)
        {
            IQueryable<Product> query = DbContext.Set<Product>().AsNoTracking();
            if (isActive.HasValue) query = query.Where(a => a.IsActive == isActive);
            if (isDeleted.HasValue) query = query.Where(a => a.IsDeleted == isDeleted);
            pageSize = pageSize > 100 ? 100 : pageSize;
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
            return new Result(ResultStatus.Succes, new ProductListDto
            {
                Products = await query.Skip((currentPage - 1) * pageSize).Take(pageSize).Select(a => Mapper.Map<Product>(a)).ToListAsync(),
                TotalCount = await query.CountAsync(),
                PageSize = pageSize,
                IsAscending = isAscending,
                CurrentPage = currentPage
            });
        }

        public async Task<IResult> GetAllWithoutPageAsync(bool? isActive, bool? isDeleted, bool isAscending, OrderBy orderBy)
        {
            IQueryable<Product> query = DbContext.Set<Product>();
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
            return new Result(ResultStatus.Succes, new ProductListDto
            {
                Products = await query.Select(a => Mapper.Map<Product>(a)).ToListAsync(),
                TotalCount = await query.CountAsync(),
            });

        }

        public async Task<IResult> GetByIdAsync(int productId)
        {
            var product = await DbContext.Products.AsNoTracking().SingleOrDefaultAsync(a => a.Id == productId);
            if (product is null)
                throw new NotFoundException(Messages.General.ValidationError(), new Error("Böyle bir ürün bulunmamakta", "Id"));

            return new Result(ResultStatus.Succes, product);
        }

        public async Task<IResult> HardDeleteAsync(int productId)
        {
            var product = await DbContext.Products.AsNoTracking().SingleOrDefaultAsync(a => a.Id == productId);
            if (product is null)
                throw new NotFoundException(Messages.General.ValidationError(), new Error("Böyle bir ürün bulunamadı", "Id"));

            DbContext.Products.Remove(product);
            await DbContext.SaveChangesAsync();
            return new Result(ResultStatus.Succes, product, "Ürün kalıcı olarak silindi.");
        }

        public async Task<IResult> UpdateAsync(ProductUpdateDto productUpdateDto)
        {
            var oldProduct = await DbContext.Products.SingleOrDefaultAsync(a => a.Id == productUpdateDto.Id);
            if (oldProduct is null)
                throw new NotFoundException(Messages.General.ValidationError(), new Error("Böyle bir ürün bulunamadı", "Id"));

            var product = Mapper.Map<ProductUpdateDto, Product>(productUpdateDto, oldProduct);
            product.ModifiedDate = DateTime.Now;
            DbContext.Products.Update(product);
            await DbContext.SaveChangesAsync();
            return new Result(ResultStatus.Succes, product, "Ürün başarıyla güncellendi");
        }
    }
}