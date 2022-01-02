using System;
namespace Entities.Dtos.CategoryDtos
{
    public class CategoryUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Picture { get; set; }
        public string Description { get; set; }
        public int? UserId { get; set; }
        public int? CompanyId { get; set; }
        public double PossibilityPercent { get; set; }
        public int? ModifiedByUserId { get; set; }


        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

    }
}

