using System;
using Entities.Concrete;
using Shared.Entities.Abstract;

namespace Entities.Dtos.CategoryDtos
{
    public class CategoryListDto : DtoGetBase
    {
        public IEnumerable<Category> Categories { get; set; }
    }
}

