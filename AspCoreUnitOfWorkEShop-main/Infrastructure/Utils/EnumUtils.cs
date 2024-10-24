using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;

namespace Infrastructure.Utils
{
    public static class EnumUtils
    {
        public static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }
        /// <summary>
        /// گرفتن نام لاتین عضو
        /// </summary>
        public static string GetDescriptionOrDefault<T>(this T enumerationValue) where T : struct
        {
            string temp = enumerationValue.GetDescriptionOrNull();
            if (string.IsNullOrWhiteSpace(temp))
                return enumerationValue.ToString();
            else
                return temp;
        }
        public static string GetDescriptionOrNull<T>(this T enumerationValue) where T : struct
        {
            Type type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");
            }

            //Tries to find a DescriptionAttribute for a potential friendly name
            //for the enum
            MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DisplayNameAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    //Pull out the description value
                    return ((DisplayNameAttribute)attrs[0]).DisplayName;
                }
            }
            //If we have no description attribute, just return the ToString of the enum
            return null;
        }


        /// <summary>
        /// گرفتن متن دسکریپشن عضو
        /// </summary>
        /// <param name="GenericEnum"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum GenericEnum)
        {
            Type genericEnumType = GenericEnum.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(GenericEnum.ToString());
            if ((memberInfo != null && memberInfo.Length > 0))
            {
                var _Attribs = memberInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
                if ((_Attribs != null && _Attribs.Count() > 0))
                {
                    return ((System.ComponentModel.DescriptionAttribute)_Attribs.ElementAt(0)).Description;
                }
            }
            return GenericEnum.ToString();
        }


        /// <summary>
        /// گرفتن عضو بعدی
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="v"></param>
        /// <returns></returns>
        public static T Next<T>(this T v) where T : struct
        {
            return Enum.GetValues(v.GetType()).Cast<T>().Concat(new[] { default(T) }).SkipWhile(e => !v.Equals(e)).Skip(1).First();
        }


        /// <summary>
        /// گرفتن عضو قبلی
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="v"></param>
        /// <returns></returns>
        public static T Previous<T>(this T v) where T : struct
        {            
            return Enum.GetValues(v.GetType()).Cast<T>().Concat(new[] { default(T) }).Reverse().SkipWhile(e => !v.Equals(e)).Skip(1).First();
        }


        /// <summary>
        /// گرفتن لیست مقادیر
        /// Enumaration.GetValues<EnumQCat>()
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }


        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            .GetName();
        }
    }
}