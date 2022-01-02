namespace Entities.Dtos.PremiumProductDtos
{
    public class PremiumProductUpdateDto
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public decimal Price { get; set; }
        public double Discount { get; set; }
        public int CompanyId { get; set; }

    }
}