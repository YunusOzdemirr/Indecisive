using Entities.Dtos.RoleDtos;
using Shared.Entities.ComplexTypes;
using Shared.Entities.Concrete;
using Shared.Utilities.Results.Abstract;

namespace Services.Abstract
{
    public interface IRoleService
    {
        public Task<IResult> AddAsync(RoleAddDto roleAddDto);
        public Task<IResult> UpdateAsync(RoleUpdateDto roleUpdate);
        public Task<IResult> GetAllAsync(GetAll getAll);
        public Task<IResult> GetAllWithoutPageAsync(bool? isActive, bool? isDeleted, bool isAscending, OrderBy orderBy);
        public Task<IResult> GetByIdAsync(int roleId);
        public Task<IResult> GetByNameAsync(string Name);
        public Task<IResult> DeleteAsync(int roleId);
        public Task<IResult> HardDeleteAsync(int roleId);

    }
}