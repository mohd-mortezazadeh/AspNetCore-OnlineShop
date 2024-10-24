using Domain.Entities;

using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task CreateAsync(OrderDto dto);
        void Update(Guid id, OrderDto dto);
        Task<OrderDto> GetOrderById(Guid id);
        Task<List<OrderDto>> GetOrderListAsync();
        void DeleteOrder(OrderDto dto);
        Task DeleteOrderAsync(Guid id);
        IEnumerable<OrderVm> ListVM(IEnumerable<Order> listSelected, OrderReadVm search = null);
        OrderVm MapEntityToVm(Order modelItem);
        OrderDto MapVmToDto(OrderVm modelIVm);
        Task<bool> IsAvailable(OrderDto dto);
    }
}
