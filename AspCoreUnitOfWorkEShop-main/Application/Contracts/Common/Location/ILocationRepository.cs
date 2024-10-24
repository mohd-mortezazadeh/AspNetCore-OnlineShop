using Domain.Entities;

using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Application.Contracts
{
    public interface ILocationRepository : IGenericRepository<Location>
    {
        IEnumerable<LocationVm> ListModel(IEnumerable<Location> listSelected, LocationReadVm search=null);
    }
}
