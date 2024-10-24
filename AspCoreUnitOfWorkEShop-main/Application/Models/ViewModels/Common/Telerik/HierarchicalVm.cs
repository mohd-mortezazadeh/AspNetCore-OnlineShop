using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class HierarchicalVm
    {
        public int ID { get; set; }
        public int? ParentID { get; set; }
        public string Name { get; set; }
        public bool HasChildren { get; set; }
        public List<HierarchicalVm> Items { get; set; }
    }
}
