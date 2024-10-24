

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Enum
{
    /// <summary>از این برای همه تب ها استفاده میشه</summary>
    public enum EnumTab
    {
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,        
    }
    public enum EnumAppSession
    {
        [Display(Name = "محصولا")]
        ProductCardItems = 1,
    }
}
