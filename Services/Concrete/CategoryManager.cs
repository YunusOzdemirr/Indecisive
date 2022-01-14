using System.Reflection.Metadata;
using System;
using AutoMapper;
using Data.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.Dtos.CategoryDtos;
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
    public class CategoryManager : ManagerBase, ICategoryService
    {
        public CategoryManager(IndecisiveContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<IResult> AddAsync(CategoryAddDto categoryAddDto)
        {


            var categoryResult = await DbContext.Categories.AsNoTracking().AnyAsync(a => a.Name == categoryAddDto.Name);
            if (categoryResult)
                throw new NotFoundException(Messages.General.ValidationError(), new Error("Bu kategori zaten mevcut"));

            var category = Mapper.Map<Category>(categoryAddDto);
            await DbContext.Categories.AddAsync(category);
            await DbContext.SaveChangesAsync();
            return new Result(ResultStatus.Succes, category);
        }

        public async Task<IResult> DeleteAsync(int categoryId)
        {
            var category = await DbContext.Categories.AsNoTracking().SingleOrDefaultAsync(a => a.Id == categoryId);
            if (category == null)
                throw new NotFoundException(Messages.General.ValidationError(), new Error("Böyle bir kategori bulunmamakta", "CategoryId"));
            category.IsDeleted = true;
            category.IsActive = false;
            DbContext.Categories.Update(category);
            await DbContext.SaveChangesAsync();
            return new Result(ResultStatus.Succes, category);
        }

        public async Task<IResult> GetAllAsync(bool? isActive, bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy, bool includeCategoryAndProduct)
        {
            IQueryable<Category> query = DbContext.Set<Category>();
            if (isActive.HasValue) query = query.AsNoTracking().Where(a => a.IsActive == isActive);
            if (isDeleted.HasValue) query = query.AsNoTracking().Where(a => a.IsDeleted == isDeleted);
            if (includeCategoryAndProduct) query = query.AsNoTracking().Include(a => a.CategoryAndProducts);
            pageSize = pageSize > 100 ? 100 : pageSize;
            var categoryCount = query.AsNoTracking().Count();
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
            return new Result(ResultStatus.Succes, new CategoryListDto
            {
                Categories = await query.Skip((currentPage - 1) * pageSize).Take(pageSize).Select(a => Mapper.Map<Category>(a)).ToListAsync(),
                CurrentPage = currentPage,
                IsAscending = isAscending,
                TotalCount = categoryCount,
                PageSize = pageSize
            });
        }
        public async Task<IResult> GetAllWithoutPagingAsync(bool? isActive, bool? isDeleted, bool isAscending, OrderBy orderBy, bool includeCategoryAndProducts)
        {
            IQueryable<Category> query = DbContext.Set<Category>().AsNoTracking();
            if (isActive.HasValue) query = query.Where(a => a.IsActive == isActive);
            if (isDeleted.HasValue) query = query.Where(a => a.IsDeleted == isDeleted);
            if (includeCategoryAndProducts) query = query.AsNoTracking().Include(a => a.CategoryAndProducts);

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
            return new Result(ResultStatus.Succes, new CategoryListDto
            {
                Categories = await query.Select(a => Mapper.Map<Category>(a)).ToListAsync(),
                IsAscending = isAscending,
                TotalCount = query.Count(),
            }); ;
        }

        public async Task<IResult> GetByIdAsync(int categoryId, bool includeCategoryAndProducts)
        {
            IQueryable<Category> query = DbContext.Set<Category>().AsNoTracking();
            var category = await query.SingleOrDefaultAsync(a => a.Id == categoryId);
            if (includeCategoryAndProducts) query = DbContext.Categories.AsNoTracking().Include(a => a.CategoryAndProducts);
            if (category is null)
                throw new NotFoundException(Messages.General.NotFoundArgument("kategori"), new Error("Böyle bir kategori bulunmamakta", "Id"));
            return new Result(ResultStatus.Succes, category);
        }



        public async Task<IResult> UpdateAsync(CategoryUpdateDto categoryUpdateDto)
        {
            var OldCategory = await DbContext.Categories.SingleOrDefaultAsync(a => a.Id == categoryUpdateDto.Id);
            if (OldCategory is null)
                throw new NotFoundException(Messages.General.ValidationError(), new Error("Böyle bir kategori bulunamadı", "Id"));
            var category = Mapper.Map<CategoryUpdateDto, Category>(categoryUpdateDto, OldCategory);

            category.ModifiedDate = DateTime.Now;
            DbContext.Categories.Update(category);
            await DbContext.SaveChangesAsync();
            return new Result(ResultStatus.Succes, category);
        }
    }
}

