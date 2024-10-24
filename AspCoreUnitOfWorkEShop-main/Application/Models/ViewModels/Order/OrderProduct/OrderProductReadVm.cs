using Domain.Enum;
using Domain.ViewModels;
using System.Collections.Generic;

namespace Application.ViewModels
{
    public class OrderProductReadVm : BaseVM
    {
        public OrderProductReadVm()
        {
        }

        public EnumTab Tab { get; set; }
        public OrderProductPartialEnum Partial { get; set; }
        public OrderProductVm OrderProductVm { get; set; }
        public List<OrderProductVm> ListOrderProductVm { get; set; }
    }
}
