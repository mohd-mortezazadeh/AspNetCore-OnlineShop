using Domain.Entities;
using Domain.ViewModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class OrderVm: BaseVM
    {
        public OrderVm()
        {
            
        }
        public int OrdererUserId { get; set; }

        [Description("Title")]
        public decimal Title { get; set; }

        [Description("Description")]
        [StringLength(100, ErrorMessage = "Max length field {0}  can be {1} characters")]
        public string Description { get; set; }

        public string Payload { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
        public AppUser User { get; set; }
    }
}
