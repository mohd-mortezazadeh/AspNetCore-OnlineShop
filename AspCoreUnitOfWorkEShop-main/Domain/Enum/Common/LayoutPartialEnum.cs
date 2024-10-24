using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enum
{
    public enum LayoutPartialEnum
    {
        [Description("")]
        Index = 1,
        [Description("")]
        PageNavbar = 100,
        [Description("")]
        PageNavbarProduct = 101,
        [Description("")]
        PageNavbar_Admin = 110,
        [Description("")]
        PageNavbar_User = 120,
        [Description("")]
        PageFooter = 200,
        [Description("")]
        PageFooter_Admin = 201,
        [Description("")]
        PageFooter_User = 202,
        [Description("")]
        PageSidebar = 300,
        [Description("")]
        PageSidebar_Admin = 301,
        [Description("")]
        PageSidebar_User = 302,
        [Description("")]
        Page = 400,
        [Description("")]
        ETC = 500,
    }
}
