
namespace Infrastructure.Result
{
    public class CustomJsonResultMethods
    {  
        /// <summary>
       /// تبدیل این مقادیر به جی‌سون
       /// </summary>
        public static CustomJsonResult Json(bool result, string message = null, string title = null, string url = null, string button = null, EnumJsonResultType type = EnumJsonResultType.Default)
        {
            return new CustomJsonResult
            {
                Result = result,
                Message = message,
                Url = url,
                Type = type,
                Title = title,
                Button = button
            };
        }

        /// <summary>
        /// تبدیل پیغام خطای نامشخص به جی‌سون
        /// </summary>
        public static CustomJsonResult UnknownErrorJson()
        {
            return Json(false, "خطای نامشخصی رخ داده است.");
        }
    }
}
