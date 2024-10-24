using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Location:BaseEntity
    {
        public Location()
        {

        }
        public Guid? ParentId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string NO { get; set; }
        public string Description { get; set; }
        public string CreatorUserId { get; set; }
        public bool IsEnable { get; set; }
        public DateTime DateRegister { get; set; }
        public LocationTypeEnum Type { get; set; }
        public LocationStatusEnum Status { get; set; }
    }
}
