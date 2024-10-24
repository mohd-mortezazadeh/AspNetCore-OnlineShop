
namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public Product()
        {

        }

        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
