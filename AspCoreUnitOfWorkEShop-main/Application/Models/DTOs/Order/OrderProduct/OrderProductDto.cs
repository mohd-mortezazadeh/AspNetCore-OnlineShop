using Application.Models;
using System;

namespace Application.ViewModels
{
    public class OrderProductDto: BaseDto
    {
        public OrderProductDto()
        {
            
        }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
    }
}
