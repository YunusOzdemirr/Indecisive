using System;
using Entities.Concrete;
using Shared.Entities.Abstract;

namespace Entities.Dtos.CompanyDtos
{
    public class CompanyListDto : DtoGetBase
    {
        public IEnumerable<Company> Companies { get; set; }
    }
}

