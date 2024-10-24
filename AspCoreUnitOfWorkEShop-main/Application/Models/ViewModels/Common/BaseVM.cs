using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class BaseVM
    {
        public BaseVM()
        {
        }
        public Guid Id { get; set; }
        public DateTime RegisterDate { get; set; } = DateTime.Now;
        public string CreatorUserId { get; set; }
    }
}
