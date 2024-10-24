using Application.Models;

namespace Application.ViewModels
{
    public class OrderDto: BaseDto
    {
        public OrderDto()
        {
            
        }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Payload { get; set; }
    }
}
