namespace Entities.Dtos.PremiumProductDtos
{
    public class PremiumProductUpdateDto
    {
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public double Discount { get; set; }
        public int CompanyId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

    }
}