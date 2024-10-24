using Domain.Enum;
using Domain.ViewModels;
using System.Collections.Generic;

namespace Application.ViewModels
{
    public class OrderReadVm : BaseVM
    {
        public OrderReadVm()
        {
        }

        public EnumTab Tab { get; set; }
        public OrderPartialEnum Partial { get; set; }
        public OrderVm OrderVm { get; set; }
        public List<OrderVm> ListOrderVm { get; set; }
    }
}
