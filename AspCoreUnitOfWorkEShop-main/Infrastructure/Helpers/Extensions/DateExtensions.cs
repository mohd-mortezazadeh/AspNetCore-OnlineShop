
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Utils.Extensions
{
    public static class DateExtensions
    {
        public static DateTime? ConvertToMiladiDate(this string persianDate)
        {
            if (string.IsNullOrWhiteSpace(persianDate))
                return null;

            return DateTime.Parse(persianDate, new CultureInfo("fa-IR"));
        }

        public static string ConvertToPersianDate(this DateTime? date)
        {
            if (!date.HasValue)
                return string.Empty;

            return date.Value.ToString("yyyy/MM/dd", new CultureInfo("fa-IR"));
        }
    }
}
