using AutoMapper;
using Data.Concrete.EntityFramework.Context;

namespace Services.Concrete
{
    public class ManagerBase
    {
        protected IndecisiveContext DbContext { get; }
        protected IMapper Mapper { get; }
        public ManagerBase(IndecisiveContext dbContext, IMapper mapper)
        {
            DbContext = dbContext;
            Mapper = mapper;
        }
    }
}

