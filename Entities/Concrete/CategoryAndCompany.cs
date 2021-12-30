using System;
namespace Entities.Concrete
{
    public class CategoryAndCompany
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}

