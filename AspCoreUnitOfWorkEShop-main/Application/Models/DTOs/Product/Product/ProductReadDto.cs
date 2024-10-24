using Application.Models;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.ViewModels
{
    public class ProductReadDto : BaseDto
    {
        public ProductReadDto()
        {
            Products = new List<Product>();
        }

        public decimal ProductsPrice { get; set; }
        public List<Product> Products { get; set; }
    }
}
