

using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Result
{
    public enum EnumJsonResultType
    {
        Default = 0,
        Success = 1,
        Info = 2,
        Warning = 3,
        Danger = 4
    }
    public class CustomJsonResult
    {
        public bool Result { get; set; }
        public EnumJsonResultType Type { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Button { get; set; }
        public string Url { get; set; }

        /// <summary>
        /// تبدیل مقادیر موجود در کلاس جاری به جی‌سون
        /// </summary>
        //public JsonResult ConvertToJson()
        //{
        //    return new JsonResult
        //    {
        //        Data = new
        //        {
        //            result = Result,
        //            type = Type,
        //            title = Title,
        //            message = Message,
        //            button = Button,
        //            url = Url
        //        },
        //        ContentEncoding = System.Text.Encoding.UTF8,
        //        ContentType = "application/json",
        //        JsonRequestBehavior = JsonRequestBehavior.AllowGet
        //    };
        //}
    }
}
