using Domain.Entities;
using Domain.Enum;

namespace Application.ViewModels
{
    public class LayoutReadVm
    {
        public LayoutReadVm()
        {
        }

        public int Id { get; set; }

        public LayoutPartialEnum Partial { get; set; }
        public AppUser AppUser { get; set; }
    }
}
