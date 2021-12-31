﻿using System;
using Shared.Entities.Abstract;

namespace Entities.Concrete
{
    public class Category : EntityBase<int>, IEntity
    {
        public string Name { get; set; }
        public byte[] Picture { get; set; }
        public string Description { get; set; }
        public double PossibilityPercent { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public ICollection<CategoryAndProduct> CategoryAndProducts { get; set; }
    }
}

