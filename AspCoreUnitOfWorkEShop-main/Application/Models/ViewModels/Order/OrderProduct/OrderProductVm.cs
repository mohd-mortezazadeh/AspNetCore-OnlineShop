using Domain.Entities;
using Domain.ViewModels;
using System;

namespace Application.ViewModels
{
    public class OrderProductVm : BaseVM
    {
        public OrderProductVm()
        {
            
        }

        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }

        public string Payload { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
