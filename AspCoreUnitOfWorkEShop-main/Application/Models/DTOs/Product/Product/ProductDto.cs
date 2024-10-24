using Application.Models;

namespace Application.ViewModels
{
    public class ProductDto : BaseDto
    {
        public ProductDto()
        {
            
        }

        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
