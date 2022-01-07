using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using AutoMapper;
using Data.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.Dtos.CategoryAndProductDtos;
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
    public class CategoryAndProductManager : ManagerBase, ICategoryAndProductService
    {
        public CategoryAndProductManager(IndecisiveContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<IResult> AddAsync(CategoryAndProductAddDto categoryAndProductAddDto)
        {
            var category = await DbContext.Categories.SingleOrDefaultAsync(a => a.Id == categoryAndProductAddDto.CategoryId);
            if (category == null)
                throw new NotFoundException(Messages.General.NotFoundArgument("kategori"), "Böyle bir kategori bulunamadı", "CategoryId");
            var product = await DbContext.Products.SingleOrDefaultAsync(a => a.Id == categoryAndProductAddDto.ProductId);
            if (product == null)
                throw new NotFoundException(Messages.General.NotFoundArgument("ürün"), new Error("Böyle bir ürün bulunamadı", "ProductId"));
            var categoryAndProduct = Mapper.Map<CategoryAndProduct>(categoryAndProductAddDto);
            categoryAndProduct.Category = category;
            categoryAndProduct.Product = product;
            DbContext.CategoryAndProducts.Add(categoryAndProduct);
            await DbContext.SaveChangesAsync();
            return new Result(ResultStatus.Succes, categoryAndProduct);
        }

        public async Task<IResult> DeleteAsync(int categoryId, int productId)
        {
            var categoryAndProduct = await DbContext.CategoryAndProducts.SingleOrDefaultAsync(a => a.CategoryId == categoryId && a.ProductId == productId);
            if (categoryAndProduct == null)
                throw new NotFoundException(Messages.General.NotFoundArgument("Kategoriye ait"), new Error("Böyle bir kategoriye ait ürün bulunamamıştır", "CategoryId && ProductId"));
            DbContext.CategoryAndProducts.Remove(categoryAndProduct);
            await DbContext.SaveChangesAsync();
            return new Result(ResultStatus.Succes, categoryAndProduct, "Başarıyla silindi");
        }

        public async Task<IResult> GetAllAsync(bool isAscending, OrderBy orderBy, bool includeCategory, bool includeProduct)
        {
            IQueryable<CategoryAndProduct> query = DbContext.Set<CategoryAndProduct>().AsNoTracking();
            if (includeCategory) query = query.Include(a => a.Category);
            if (includeProduct) query = query.Include(a => a.Product);
            // var categoryAndProduct = await DbContext.CategoryAndProducts.ToListAsync();
            switch (orderBy)
            {
                case OrderBy.Id:
                    query = isAscending ? query.OrderBy(a => a.CategoryId) : query.OrderBy(a => a.ProductId);
                    break;
                case OrderBy.Az:
                    query = isAscending ? query.OrderBy(a => a.Category.Name) : query.OrderBy(a => a.Product.Name);
                    break;
                case OrderBy.ModifiedDate:
                    query = isAscending ? query.OrderBy(a => a.Category.ModifiedDate) : query.OrderBy(a => a.Product.Name);
                    break;
                default:
                    query = isAscending ? query.OrderBy(a => a.Category.CreatedDate) : query.OrderBy(a => a.Product.CreatedDate);
                    break;
            }

            return new Result(ResultStatus.Succes, new CategoryAndProductListDto
            {
                CategoryAndProducts = await query.Select(a => Mapper.Map<CategoryAndProduct>(a)).ToListAsync(),
                TotalCount = await query.CountAsync(),
                IsAscending = isAscending,
            });
        }

        public async Task<IResult> GetById(int categoryId, int productId)
        {
            var categoryAndProduct = await DbContext.CategoryAndProducts.Include(a => a.Product).Include(a => a.Category).SingleOrDefaultAsync(a => a.CategoryId == categoryId && a.ProductId == productId);
            if (categoryAndProduct == null)
                throw new NotFoundException(Messages.General.NotFoundArgument("Kategoriye ait"), new Error("Böyle bir kategoriye ait ürün bulunamadı", "CategoryId && ProductId"));
            return new Result(ResultStatus.Succes, categoryAndProduct);
        }

        public async Task<IResult> GetCategoryByProductId(int productId)
        {
            var categoryAndProducts = await DbContext.CategoryAndProducts.Include(a => a.Category).Where(a => a.ProductId == productId).ToListAsync();
            if (categoryAndProducts is null)
                throw new NotFoundException(Messages.General.NotFoundArgument("ürün'e ait kategori"), new Error("Böyle bir ürün'e ait kategori bulunamadı.", "productId"));
            List<Category> categories = new List<Category>();
            foreach (var item in categoryAndProducts)
            {
                categories.Add(item.Category);
            }
            return new Result(ResultStatus.Succes, categories);
        }

        public async Task<IResult> GetProductByCategoryId(int categoryId)
        {
            var categoryAndProduct = await DbContext.CategoryAndProducts.Include(a => a.Product).Where(a => a.CategoryId == categoryId).ToListAsync();
            if (categoryAndProduct is null)
                throw new NotFoundException(Messages.General.NotFoundArgument("kategoriye ait ürün"), new Error("Böyle bir kategoriye ait ürün bulunamadı.", "categoryId"));
            List<Product> products = new List<Product>();
            foreach (var item in categoryAndProduct)
            {
                products.Add(item.Product);
            }
            return new Result(ResultStatus.Succes, products);
        }

    }
}