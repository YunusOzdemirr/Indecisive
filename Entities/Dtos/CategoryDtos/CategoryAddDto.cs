﻿namespace Entities.Dtos.CategoryDtos
{
    public class CategoryAddDto
    {
        public string Name { get; set; }
        public byte[]? Picture { get; set; }
        public string Description { get; set; }
        public double PossibilityPercent { get; set; }
        public int? CreatedByUserId { get; set; }
    }
}

