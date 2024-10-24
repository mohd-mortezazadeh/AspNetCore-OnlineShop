using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Utils
{
    public static class CookieUtils
    {

        public static void Create(HttpContext context, string token, string value)
        {
            context.Response.Cookies.Append(token, value, getCookieOptions(context));
        }

        public static string Read(HttpContext context, string token)
        {
            string cookieValue;
            if (!context.Request.Cookies.TryGetValue(token, out cookieValue))
            {
                return null;
            }
            return cookieValue;
        }

        public static void Delete(HttpContext context, string token)
        {
            if (context.Request.Cookies.ContainsKey(token))
            {
                context.Response.Cookies.Delete(token);
            }
        }


        public static bool Contains(HttpContext context, string token)
        {
            return context.Request.Cookies.ContainsKey(token);
        }

        /// <summary>
        /// Expires at the end of the browser's session.
        /// </summary>
        private static CookieOptions getCookieOptions(HttpContext context)
        {
            return new CookieOptions
            {
                HttpOnly = true,
                Path = context.Request.PathBase.HasValue ? context.Request.PathBase.ToString() : "/",
                Secure = context.Request.IsHttps,                
            };
        }
    }


}
