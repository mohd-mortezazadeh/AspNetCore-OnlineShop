using Domain.Entities;

using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task CreateAsync(ProductDto dto);
        void Update(Guid id, ProductDto dto);
        Task<ProductDto> GetProductById(Guid id);
        Task<List<ProductDto>> GetProductListAsync();
        void DeleteProduct(ProductDto dto);
        Task DeleteProductAsync(Guid id);
        IEnumerable<ProductVm> ListVM(IEnumerable<Product> listSelected, ProductReadVm search = null);
        ProductVm MapEntityToVm(Product modelItem);
        ProductDto MapVmToDto(ProductVm modelIVm);
        Task<ProductReadDto> ProductCard();
        string AddToCard(string payload);
        string DeleteFromCard(string payload);
    }
}
