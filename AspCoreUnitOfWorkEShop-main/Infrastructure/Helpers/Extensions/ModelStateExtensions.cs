using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Utils.Extensions
{
    public static class ModelStateExtensions
    {
        /// <summary>
        /// گرفتن تمام خطاهای مدل استیت
        /// </summary>
        /// <param name="separate">جداکننده بین هر خطا</param>
        /// <returns></returns>
        public static string GetErrorMessages(this ModelStateDictionary ModelState, string separate)
        {
            if (ModelState == null)
                return string.Empty;

            string errors = string.Empty;
            string exceptions = string.Empty;

            // get errors
            foreach (var i in ModelState.Values)
                foreach (var j in i.Errors)
                {
                    if (!string.IsNullOrWhiteSpace(j.ErrorMessage))
                        errors += j.ErrorMessage + separate;
                    if (j.Exception != null)
                        exceptions += j.Exception.Message + separate;
                }

            return (errors + exceptions).TrimEnd(separate.ToArray());
        }

        /// <summary>
        /// حذف خطاهای یک فیلد از مدل استیت
        /// </summary>
        public static void ClearErrors(this ModelStateDictionary ModelState, string key)
        {
            if (ModelState[key] != null && ModelState[key].Errors != null)
                ModelState[key].Errors.Clear();
        }

        /// <summary>
        /// حذف خطاهای تعدادی فیلد از مدل استیت
        /// </summary>
        public static void ClearErrors(this ModelStateDictionary ModelState, params string[] keys)
        {
            foreach (string key in keys)
                ModelState.ClearErrors(key);
        }

        /// <summary>
        /// حذف خطاهای تعدادی فیلد از مدل استیت که شامل یک رشته هستند
        /// </summary>
        public static void ClearErrorsByPartOfKey(this ModelStateDictionary ModelState, string partOfKey)
        {
            foreach (string key in ModelState.Keys.Where(w => w.Contains(partOfKey)))
                ModelState.ClearErrors(key);
        }

    }
}
