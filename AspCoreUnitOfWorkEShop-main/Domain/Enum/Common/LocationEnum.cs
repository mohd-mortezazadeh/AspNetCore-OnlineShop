using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enum
{
    public enum LocationPartialEnum
    {
        [Description("")]
        Index = 1,
        [Description("")]
        Create = 100,
        [Description("")]
        Read = 200,
        [Description("")]
        Delete = 300,
        [Description("")]
        Update = 400,
        [Description("")]
        ETC = 500,
    }

    public enum LocationTypeEnum
    {
        [Description("Country")]
        Country = 1,
        [Description("Province")]
        Province = 2,
        [Description("City")]
        City = 3,
        [Description("Region")]
        Region = 4,
    }

    public enum LocationStatusEnum
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
}
