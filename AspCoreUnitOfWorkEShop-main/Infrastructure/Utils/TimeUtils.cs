using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsleAsl.Utils
{
    public static class TimeUtils
    {
        public static DateTime? ToTime(string timeString)
        {
            if (string.IsNullOrEmpty(timeString)) {
                return null;
            } 
            else if (timeString.Count()<8)
            {
                timeString += ":00";
            }
            DateTime dateTime = DateTime.ParseExact(timeString, "HH:mm:ss",
                                        CultureInfo.InvariantCulture);
            return dateTime;
        }
    }
}
