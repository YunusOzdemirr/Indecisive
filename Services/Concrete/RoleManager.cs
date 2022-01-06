using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Data.Common;
using AutoMapper;
using Data.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.Dtos.RoleDtos;
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
    public class RoleManager : ManagerBase, IRoleService
    {
        public RoleManager(IndecisiveContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<IResult> AddAsync(RoleAddDto roleAddDto)
        {
            var roleResult = await DbContext.Roles.SingleOrDefaultAsync(a => a.Name == roleAddDto.Name);
            if (roleResult != null)
                throw new ExistArgumentException(Messages.General.IsExistArgument(roleAddDto.Name + "Adlı Rol"), new Error("Bu Role Mevcut", "Name"));

            var role = Mapper.Map<Role>(roleAddDto);
            await DbContext.Roles.AddAsync(role);
            await DbContext.SaveChangesAsync();
            return new Result(ResultStatus.Succes, role, $"{roleAddDto.Name} Rol Başarıyla Eklendi");
        }

        public async Task<IResult> DeleteAsync(int roleId)
        {
            var roleResult = await DbContext.Roles.SingleOrDefaultAsync(a => a.Id == roleId);
            if (roleResult == null)
                throw new NotFoundException(Messages.General.NotFoundArgument("Ürün"), new Error("Böyle bir role bulunamadı", "Id"));

            roleResult.IsActive = false;
            roleResult.IsDeleted = true;
            roleResult.ModifiedDate = DateTime.Now;
            DbContext.Roles.Update(roleResult);
            await DbContext.SaveChangesAsync();
            return new Result(ResultStatus.Succes, roleResult, "Başarıyla Silindi");
        }

        public async Task<IResult> GetAllAsync(GetAll getAll)
        {
            IQueryable<Role> query = DbContext.Set<Role>().AsNoTracking();
            if (getAll.IsActive.HasValue) query = query.Where(a => a.IsActive == getAll.IsActive);
            if (getAll.IsDeleted.HasValue) query = query.Where(a => a.IsDeleted == getAll.IsDeleted);
            int totalCount = await query.CountAsync();
            getAll.PageSize = getAll.PageSize > 100 ? 100 : getAll.PageSize;
            switch (getAll.orderBy)
            {
                case OrderBy.Id:
                    query = getAll.IsAscending ? query.OrderBy(a => a.Id) : query.OrderByDescending(a => a.Id);
                    break;
                case OrderBy.Az:
                    query = getAll.IsAscending ? query.OrderBy(a => a.Name) : query.OrderByDescending(a => a.Name);
                    break;
                case OrderBy.ModifiedDate:
                    query = getAll.IsAscending ? query.OrderBy(a => a.ModifiedDate) : query.OrderByDescending(a => a.ModifiedDate);
                    break;
                default:
                    query = getAll.IsAscending ? query.OrderBy(a => a.CreatedDate) : query.OrderByDescending(a => a.CreatedDate);
                    break;
            }
            return new Result(ResultStatus.Succes, new RoleListDto
            {
                Roles = await query.Skip((getAll.CurrentPage - 1) * getAll.PageSize).Take(getAll.PageSize).Select(a => Mapper.Map<Role>(a)).ToListAsync(),
                CurrentPage = getAll.CurrentPage,
                PageSize = getAll.PageSize,
                TotalCount = totalCount,
                IsAscending = getAll.IsAscending
            });
        }

        public async Task<IResult> GetAllWithoutPageAsync(bool? isActive, bool? isDeleted, bool isAscending, OrderBy orderBy)
        {
            IQueryable<Role> query = DbContext.Set<Role>().AsNoTracking();
            if (isActive.HasValue) query = query.Where(a => a.IsActive == isActive);
            if (isDeleted.HasValue) query = query.Where(a => a.IsDeleted == isDeleted);
            int totalCount = await query.CountAsync();
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
            return new Result(ResultStatus.Succes, new RoleListDto
            {
                Roles = await query.Select(a => Mapper.Map<Role>(a)).ToListAsync(),
                TotalCount = totalCount,
                IsAscending = isAscending,
            });

        }

        public async Task<IResult> GetByIdAsync(int roleId)
        {
            var roleResult = await DbContext.Roles.SingleOrDefaultAsync(a => a.Id == roleId);
            if (roleResult == null)
                throw new NotFoundException(Messages.General.NotFoundArgument("Rol"), new Error("Böyle bir Role bulunamadı "));
            return new Result(ResultStatus.Succes, roleResult);
        }

        public Task<IResult> GetByNameAsync(string Name)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> HardDeleteAsync(int roleId)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> UpdateAsync(RoleUpdateDto roleUpdate)
        {
            throw new NotImplementedException();
        }
    }
}