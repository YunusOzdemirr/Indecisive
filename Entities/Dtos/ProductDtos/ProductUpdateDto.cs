using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Dtos.ProductDtos
{
    public class ProductUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double PossibilityPercent { get; set; }
        public int? CompanyId { get; set; }
        public int? UserId { get; set; }
    }
}