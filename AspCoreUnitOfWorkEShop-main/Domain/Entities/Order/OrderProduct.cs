using System;

namespace Domain.Entities
{
    public class OrderProduct : BaseEntity
    {
        public OrderProduct()
        {

        }

        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }

        public Order Order { get; set; }
    }
}
