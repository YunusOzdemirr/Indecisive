using System;
using Entities.ComplexTypes;

namespace Entities.Dtos.CompanyDtos
{
    public class CompanyUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double PossibilityPercent { get; set; }
        public CompanyType CompanyType { get; set; }
        public int PremiumProductCount { get; set; }
    }
}

