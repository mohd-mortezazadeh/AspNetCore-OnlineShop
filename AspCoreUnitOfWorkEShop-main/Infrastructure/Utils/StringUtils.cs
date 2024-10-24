using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Infrastructure.Utils
{
    public static class StringUtils
    {
        /// <summary>
        /// تبدیل رشته به لیست رشته  
        /// </summary>
        /// <param name="Separator">جدا کننده رشته</param>
        public static List<string> SelectedIds(string SelectedIds, char Separator = '.')
        {
            if (SelectedIds==null)
            {
                return new List<string>();
            }
            return SelectedIds.Split(new char[] { Separator }).ToList();
        }

        /// <summary>
        /// تبدیل رشته به لیست رشته  
        /// </summary>
        /// <param name="Separator">جدا کننده رشته</param>
        public static string Joiner(List<int> list, char Separator = '.')
        {
            string result = string.Empty;

            foreach (var item in list)
            {
                result += item + ",";
            }

            return result;
        }


        /// <summary>
        /// تبدیل عدد فلوت به رشته قابل نمایش
        /// </summary>
        /// <param name="decimalSeparator">جدا کننده اعشار</param>
        public static string ToDisplayString(this float input, char decimalSeparator = '.')
        {
            char separator = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            return input.ToString().Replace(separator, decimalSeparator);
        }
       
        /// <summary>
        /// آیا این رشته به فلوت تبدیل میشود؟
        /// </summary>
        /// <param name="decimalSeparators">کاراکترهای مجاز جدا کننده اعشار</param>
        public static bool TryParseToFloat(this string input, out float output, params char[] decimalSeparators)
        {
            char separator = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            foreach (char i in decimalSeparators)
                input = input.Replace(i, separator);
            return float.TryParse(input, out output);
        }

        /// <summary>
        /// تبدیل رشته به فلوت
        /// </summary>
        /// <param name="decimalSeparators">کاراکترهای مجاز جدا کننده اعشار</param>
        public static float ToFloat(this string input, params char[] decimalSeparators)
        {
            char separator = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            foreach (char i in decimalSeparators)
                input = input.Replace(i, separator);
            return float.Parse(input);
        }

        /// <summary>
        /// دریافت اولین حرف از هر کلمه یک رشته
        /// </summary>
        /// <param name="decimalSeparator">جدا کننده</param>
        public static string GetFirstLetterOfStringWords(string str ,char separator = '.')
        {
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }
            string[] strSplit = str.Split();
            string result = string.Empty;
            foreach (string res in strSplit)
            {
                if (!string.IsNullOrEmpty(res))
                {
                    result += res.Substring(0, 1);
                }                
            }

            return result;
        }
    }
}