namespace Entities.Dtos.PremiumProductDtos
{
    public class PremiumProductAddDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public double Discount { get; set; }
        public int CompanyId { get; set; }

    }
}