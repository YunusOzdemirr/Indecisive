using System;
using Entities.ComplexTypes;

namespace Entities.Dtos.CompanyDtos
{
    public class CompanyAddDto
    {
        public string Name { get; set; }
        public double PossibilityPercent { get; set; }
        public CompanyType CompanyType { get; set; }
    }
}

