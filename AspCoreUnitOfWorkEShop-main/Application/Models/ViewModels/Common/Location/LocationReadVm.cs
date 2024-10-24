using Domain.Enum;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class LocationReadVm:BaseVM
    {
        public LocationReadVm()
        {
            ListLocationVm = new List<LocationVm>();
        }

        //search        
        public Guid? ParentId { get; set; }
        public string Name { get; set; }
        
        public LocationPartialEnum Partial { get; set; }
        //list
        public List<LocationVm> ListLocationVm { get; set; }
    }
}
