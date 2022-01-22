using System.Linq;
using AutoMapper;
using Data.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.Dtos.SubscribeDtos;
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
    public class SubscribeManager : ManagerBase, ISubscribeService
    {
        public SubscribeManager(IndecisiveContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<IResult> AddAsync(SubscribeAddDto subscribeAddDto)
        {
            var isExist = await DbContext.Subscribes.SingleOrDefaultAsync(a => a.UserId == subscribeAddDto.UserId);
            if (isExist != null)
                throw new ExistArgumentException(Messages.General.IsExistArgument("Abonelik"), new Error("Bu abonelik zaten mevcut", "UserId"));

            var subscribe = Mapper.Map<Subscribe>(subscribeAddDto);
            subscribe.ExpireDate = DateTime.Now.AddDays(30);
            subscribe.StartDate = DateTime.Now;
            await DbContext.Subscribes.AddAsync(subscribe);
            await DbContext.SaveChangesAsync();

            return new Result(ResultStatus.Succes, subscribe, "Bu abonelik başarıyla tamamlandı.");
        }

        public async Task<IResult> DeleteAsync(int Id)
        {
            var subscribe = await DbContext.Subscribes.SingleOrDefaultAsync(a => a.Id == Id);
            if (subscribe == null)
                throw new NotFoundException(Messages.General.NotFoundArgument("Abonelik"), new Error("Hata", "Id"));

            subscribe.IsDeleted = true;
            subscribe.IsActive = false;
            subscribe.ModifiedDate = DateTime.Now;
            DbContext.Subscribes.Update(subscribe);
            await DbContext.SaveChangesAsync();
            return new Result(ResultStatus.Succes, subscribe, "Abonelik Başarıyla silindi");
        }

        public async Task<IResult> GetAllAsync(bool? isActive, bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy)
        {
            IQueryable<Subscribe> query = DbContext.Set<Subscribe>().AsNoTracking();
            if (isActive.HasValue) query = query.Where(a => a.IsActive == isActive);
            if (isDeleted.HasValue) query = query.Where(a => a.IsDeleted == isDeleted);

            pageSize = pageSize > 100 ? 100 : pageSize;
            switch (orderBy)
            {
                case OrderBy.Id:
                    query = isAscending ? query.OrderBy(a => a.Id) : query.OrderByDescending(a => a.Id);
                    break;
                case OrderBy.CreatedDate:
                    query = isAscending ? query.OrderBy(a => a.StartDate) : query.OrderByDescending(a => a.StartDate);
                    break;
                default:
                    query = isAscending ? query.OrderBy(a => a.ExpireDate) : query.OrderByDescending(a => a.ExpireDate);
                    break;
            }
            return new Result(ResultStatus.Succes, new SubscribeListDto
            {
                Subscribes = await query.Skip((currentPage - 1) * pageSize).Take(pageSize).Select(a => Mapper.Map<Subscribe>(a)).ToListAsync(),
                IsAscending = isAscending,
                TotalCount = await query.CountAsync(),
                PageSize = pageSize,
                CurrentPage = currentPage
            });
        }

        public async Task<IResult> GetByIdAsync(int Id)
        {
            var subscribe = await DbContext.Subscribes.SingleOrDefaultAsync(a => a.Id == Id);
            if (subscribe == null)
                throw new NotFoundException(Messages.General.NotFoundArgument("Abonelik"), new Error("Hata", "Id"));

            return new Result(ResultStatus.Succes, subscribe);
        }

        public async Task<IResult> HardDeleteAsync(int Id)
        {
            var subscribe = await DbContext.Subscribes.SingleOrDefaultAsync(a => a.Id == Id);
            if (subscribe == null)
                throw new NotFoundException(Messages.General.NotFoundArgument("Abonelik"), new Error("Hata", "Id"));
            DbContext.Subscribes.Remove(subscribe);
            await DbContext.SaveChangesAsync();
            return new Result(ResultStatus.Succes, "Abonelik Başarıyla kalıcı olarak silindi");
        }

        public async Task<IResult> UpdateAsync(SubscribeUpdateDto subscribeUpdateDto)
        {
            var OldSubscribe = await DbContext.Subscribes.SingleOrDefaultAsync(a => a.Id == subscribeUpdateDto.Id);
            if (OldSubscribe == null)
                throw new NotFoundException(Messages.General.NotFoundArgument("Abonelik"), new Error("Hata", "Id"));

            var newSubscribe = Mapper.Map<SubscribeUpdateDto, Subscribe>(subscribeUpdateDto, OldSubscribe);
            newSubscribe.ModifiedDate = DateTime.Now;
            DbContext.Subscribes.Update(newSubscribe);
            await DbContext.SaveChangesAsync();
            return new Result(ResultStatus.Succes, newSubscribe, "Başarıyla güncellendi");
        }
    }
}