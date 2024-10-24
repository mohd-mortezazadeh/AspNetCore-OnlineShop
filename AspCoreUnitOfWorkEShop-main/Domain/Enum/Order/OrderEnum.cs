using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enum
{
    public enum OrderStatusEnum
    {
        [Description("InActive")]
        InActive = -2,
        [Description("Delete")]
        Delete = -1,
        [Description("Wait")]
        Wait = 1,
        [Description("Active")]
        Active = 2,
    }

    public enum OrderPartialEnum
    {
        [Description("")]
        Index = 1,
        [Description("")]
        Create = 100,
        [Description("")]
        Read = 200,
        [Description("")]
        Read_Select =201,
        [Description("")]
        Delete = 300,
        [Description("")]
        Delete_Many = 301,
        [Description("")]
        Update = 400,
        [Description("")]
        ETC = 500,
        [Description("")]
        ETC_PageTab =501
    }
}
