using System.Collections.Generic;

namespace Domain.Entities
{
    public class Order : BaseEntity
    {
        public Order()
        {

        }

        public string OrdererUserId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
