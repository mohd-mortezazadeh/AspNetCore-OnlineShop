using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Utils
{
    public static class JsonUtils
    {
        /// <summary>
        /// تبدیل شی موردنظر به جیسون
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static object SerializeObject<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// تبدیل جیسون به شی موردنظر
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T DeSerializeObject<T>(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                return JsonConvert.DeserializeObject<T>("");
            }
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
