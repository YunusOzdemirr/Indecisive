namespace Entities.Concrete
{
    public class CompanyAndProduct
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}