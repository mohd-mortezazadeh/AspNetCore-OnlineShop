
using Domain.Entities;
using Domain.Enum;

namespace Application.ViewModels
{
    public class LayoutVm
    {
        public LayoutVm()
        {            
        }
        public AppUser AppUser { get; set; }
        public LayoutPartialEnum Partial { get; set; }
    }
}
