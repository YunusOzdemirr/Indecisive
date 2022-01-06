using Shared.Entities.ComplexTypes;

namespace Shared.Entities.Concrete
{
    public class GetAll
    {
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public bool IsAscending { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }

        public OrderBy orderBy { get; set; }






    }
}