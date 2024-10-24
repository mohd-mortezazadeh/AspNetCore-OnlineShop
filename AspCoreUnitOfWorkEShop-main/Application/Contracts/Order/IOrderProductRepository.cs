using Domain.Entities;

using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IOrderProductRepository : IGenericRepository<OrderProduct>
    {
        Task CreateAsync(OrderProductDto dto);
        void Update(Guid id, OrderProductDto dto);
        Task<OrderProductDto> GetOrderProductById(Guid id);
        Task<List<OrderProductDto>> GetOrderProductListAsync();
        void DeleteOrderProduct(OrderProductDto dto);
        Task DeleteOrderProductAsync(Guid id);
        IEnumerable<OrderProductVm> ListVM(IEnumerable<OrderProduct> listSelected, OrderProductReadVm search = null);
        OrderProductVm MapEntityToVm(OrderProduct modelItem);
        OrderProductDto MapVmToDto(OrderProductVm modelIVm);
    }
}
