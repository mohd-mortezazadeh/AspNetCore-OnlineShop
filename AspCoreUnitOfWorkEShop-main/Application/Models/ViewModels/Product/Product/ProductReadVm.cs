using Domain.Enum;
using Domain.ViewModels;
using System.Collections.Generic;

namespace Application.ViewModels
{
    public class ProductReadVm : BaseVM
    {
        public ProductReadVm()
        {
        }


        public ProductPartialEnum Partial { get; set; }
        public ProductVm ProductVm { get; set; }
        public List<ProductVm> ListProductVm { get; set; }
        public ProductReadDto Card { get; set; }
        public EnumTab Tab { get; set; }
    }
}
