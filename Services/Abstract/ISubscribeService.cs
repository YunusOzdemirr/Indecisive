using Entities.Dtos.SubscribeDtos;
using Shared.Entities.ComplexTypes;
using Shared.Utilities.Results.Abstract;

namespace Services.Abstract
{
    public interface ISubscribeService
    {
        public Task<IResult> AddAsync(SubscribeAddDto subscribeAddDto);
        public Task<IResult> UpdateAsync(SubscribeUpdateDto subscribeUpdateDto);
        public Task<IResult> GetAllAsync(bool? isActive, bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy);
        public Task<IResult> DeleteAsync(int Id);
        public Task<IResult> HardDeleteAsync(int Id);
        public Task<IResult> GetByIdAsync(int Id);
    }
}