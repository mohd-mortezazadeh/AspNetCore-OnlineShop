using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enum
{
    public enum EnumRoleMain
    {
        [Description("ادمین")]
        Admin = 1,
        [Description("کاربر معمولی")]
        User = 2
    }
}
