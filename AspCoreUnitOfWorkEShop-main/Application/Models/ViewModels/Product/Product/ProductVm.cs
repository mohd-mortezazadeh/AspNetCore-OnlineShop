using Domain.Entities;
using Domain.ViewModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class ProductVm: BaseVM
    {
        public ProductVm()
        {
            
        }

        [Description("Title")]
        [StringLength(100, ErrorMessage = "Max length field {0}  can be {1} characters")]
        public string Title { get; set; }

        [Description("Price")]
        public decimal Price { get; set; }

        [Description("Description")]
        [StringLength(10000, ErrorMessage = "Max length field {0}  can be {1} characters")]
        public string Description { get; set; }
        public string Payload { get; set; }

        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
