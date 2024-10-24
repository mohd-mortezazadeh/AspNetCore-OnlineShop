using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualBasic; // Install-Package Microsoft.VisualBasic
using Microsoft.VisualBasic.CompilerServices; // Install-Package Microsoft.VisualBasic

namespace Infrastructure.Utils
{
    public static class DateTimeUtils
    {
        public static PersianCalendar persianCalendar = new PersianCalendar();
        public static HijriCalendar hejriCalendar = new HijriCalendar();
        public static DateTime mdate;

        public static string ConvertMinutesToTimeFormat(string minutes)
        {
            string PersianDate = string.Empty;
            TimeSpan spMinutes = TimeSpan.FromMinutes(Convert.ToDouble(minutes));
            return spMinutes.ToString(@"hh\:mm");
        }

        /// <summary>
        /// تاریخ شمسی به صورت کوتاه
        /// </summary>
        /// <param name="date"></param>
        /// <returns>تاریخ شمسی به صورت کوتاه</returns>
        public static string PersianShortDate(DateTime date, bool asNumeric = false)
        {
            string PersianDate=string.Empty;
            mdate = date;
            try
            {
                if (asNumeric)
                {
                    PersianDate = string.Format("{0:0000}{1:00}{2:00}", persianCalendar.GetYear(mdate), persianCalendar.GetMonth(mdate), persianCalendar.GetDayOfMonth(mdate));
                }
                else
                {
                    PersianDate = string.Format("{0:0000}/{1:00}/{2:00}", persianCalendar.GetYear(mdate), persianCalendar.GetMonth(mdate), persianCalendar.GetDayOfMonth(mdate));
                }
            }
            catch (Exception)
            {                
            }
            return PersianDate;
        }

        public static DateTime? ShamsiToMiladi(string shamsiDate)
        {
            int count = shamsiDate.Count();

            if (count > 10)
            {
                return null;
            }

            string year = string.Empty;
            string month = string.Empty;
            string day = string.Empty;

            //گرفتن بخش سال
            var yearIndex = shamsiDate.IndexOf('/');
            if (yearIndex == 3)
            {
                year = "1" + shamsiDate.Substring(0, yearIndex);
            }
            else if (yearIndex == 4)
            {
                year = shamsiDate.Substring(0, yearIndex);
            }
            else
            {
                return null;
            }

            //گرفتن بخش ماه
            shamsiDate = shamsiDate.Substring(yearIndex + 1);
            var monthIndex = shamsiDate.IndexOf('/');

            if (monthIndex == 1)
            {
                month = "0" + shamsiDate.Substring(0, monthIndex);
            }
            else if (monthIndex == 2)
            {
                month = shamsiDate.Substring(0, monthIndex);
            }
            else
            {
                return null;
            }

            //گرفتن بخش روز
            shamsiDate = shamsiDate.Substring(monthIndex + 1);

            if (shamsiDate.Count() == 1)
            {
                day = "0" + shamsiDate;
            }
            else if (shamsiDate.Count() > 2)
            {
                return null;
            }
            else
            {
                day = shamsiDate;
            }

            Calendar persian = new PersianCalendar();
            DateTime date = new DateTime(int.Parse(year), int.Parse(month), int.Parse(day), persian);

            return date;
        }

        /// <summary>
        /// تاریخ شمسی به صورت بلند
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string PersianLongDate(DateTime date)
        {
            string set_p_dateRet = default;
            string dateString, ss, ms, rs;
            dateString = PersianShortDate(date);
            ss = Convert.ToString(dateString[0]) + dateString[1] + dateString[2] + dateString[3];
            ms = Convert.ToString(dateString[5]) + dateString[6];
            rs = Convert.ToString(dateString[8]) + dateString[9];
            // PersianCalenda()
            int we;
            var mon = new string[14];
            var w = new string[9];

            w[0] = "يکشنبه";
            w[1] = "دوشنبه";
            w[2] = "سه شنبه";
            w[3] = "چهارشنبه";
            w[4] = "پنجشنبه";
            w[5] = "جمعه";
            w[6] = "شنبه";

            mon[1] = "فروردين";
            mon[2] = "ارديبهشت";
            mon[3] = "خرداد";
            mon[4] = "تير";
            mon[5] = "مرداد";
            mon[6] = "شهريور";
            mon[7] = "مهر";
            mon[8] = "آبان";
            mon[9] = "آذر";
            mon[10] = "دی";
            mon[11] = "بهمن";
            mon[12] = "اسفند";


            Calendar persian= new PersianCalendar();
            DateTime date1 = new DateTime(int.Parse(ss), int.Parse(ms), int.Parse(rs), persian);

            //we = (int)DateTime.Now.DayOfWeek;
            we = (int)date1.DayOfWeek;

            set_p_dateRet = w[we] + "  " + rs + "  " + mon[Convert.ToInt32(ms)] + "  " + ss;
            return set_p_dateRet;
        }

        /// <summary>
        /// افزودن به تاریخ
        /// </summary>
        /// <param name="date"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns>تاریخ افزوده شده</returns>
        public static string AddToPersianDate(DateTime date, int year, int month, int day)
        {
            string result;

            date = date.AddYears(year);
            date = date.AddMonths(month);
            date = date.AddDays(day);

            result = string.Format("{0:0000}/{1:00}/{2:00}", persianCalendar.GetYear(date), persianCalendar.GetMonth(date), persianCalendar.GetDayOfMonth(date));

            return result;
        }

        /// <summary>
        /// تاریخ به صورت مستقل به کامل
        /// </summary>
        /// <param name="date"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns>تاریخ به صورت کامل</returns>
        public static string ApartDateToCompleteDate(string year, string month, string day)
        {
            string result;

            result = string.Format("{0:0000}/{1:00}/{2:00}", year, month, day);

            return result;
        }

        /// <summary>
        /// تاریخ کامل به صورت مستقل 
        /// </summary>
        /// <param name="date"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns>تاریخ به صورت مستقل</returns>
        public static List<string> CompleteDateToApartDate(string date)
        {
            if (string.IsNullOrEmpty(date) || !(date.Count()==10))
            {
                return new List<string>() { "", "", "" };
            }

            return new List<string>() { date.Substring(0,4), date.Substring(5, 2), date.Substring(8, 2) };
        }

        /// <summary>
        /// دریافت زمان جاری
        /// </summary>
        /// <returns></returns>
        public static string TimeShort(DateTime date, bool asNumeric = false)
        {
            string time;

            var hour = date.TimeOfDay.Hours.ToString();
            var minute = date.TimeOfDay.Minutes.ToString();
            var second = date.TimeOfDay.Seconds.ToString();

            hour = Convert.ToDouble(hour) < 10d ? "0" + hour : hour;
            minute = Convert.ToDouble(minute) < 10d ? "0" + minute : minute;
            second = Convert.ToDouble(second) < 10d ? "0" + second : second;

            time = asNumeric ? hour + minute + second : hour + ":" + minute + ":" + second;

            return time;
        }

        public static long DatePickerAsNumeric(string date)
        {
            int count = date.Count();

            if (count > 10)
            {
                return 0;
            }

            string year = string.Empty;
            string month = string.Empty;
            string day = string.Empty;

            //گرفتن بخش سال
            var yearIndex = date.IndexOf('/');
            if (yearIndex == 3)
            {
                year = "1" + date.Substring(0, yearIndex);
            }
            else if (yearIndex == 4)
            {
                year = date.Substring(0, yearIndex);
            }
            else
            {
                return 0;
            }

            //گرفتن بخش ماه
            date = date.Substring(yearIndex + 1);
            var monthIndex = date.IndexOf('/');

            if (monthIndex == 1)
            {
                month = "0" + date.Substring(0, monthIndex);
            }
            else if (monthIndex == 2)
            {
                month = date.Substring(0, monthIndex);
            }
            else
            {
                return 0;
            }

            //گرفتن بخش روز
            date = date.Substring(monthIndex + 1);

            if (date.Count() == 1)
            {
                day = "0" + date;
            }
            else if (date.Count() > 2)
            {
                return 0;
            }
            else
            {
                day = date;
            }

            return Convert.ToInt64(year + month + day);
        }

        public static string NumericAsDatePicker(long date)
        {
            var dateStr = date.ToString();

            if (dateStr.Count() != 8)
            {
                return "";
            }

            var year = dateStr.Substring(0, 4);
            var month = dateStr.Substring(4, 2);
            var second = dateStr.Substring(6, 2);

            return year + "/" + month + "/" + second;
        }


        /// <summary>
        /// تاریخ شمسی به صورت کوتاه
        /// </summary>
        /// <param name="date"></param>
        /// <returns>تاریخ شمسی به صورت کوتاه</returns>
        public static string HejriShortDate(DateTime date, bool asNumeric = false)
        {
            string PersianDate;
            mdate = date;

            if (asNumeric)
            {
                PersianDate = string.Format("{0:0000}{1:00}{2:00}", hejriCalendar.GetYear(mdate), hejriCalendar.GetMonth(mdate), hejriCalendar.GetDayOfMonth(mdate));
            }
            else
            {
                PersianDate = string.Format("{0:0000}/{1:00}/{2:00}", hejriCalendar.GetYear(mdate), hejriCalendar.GetMonth(mdate), hejriCalendar.GetDayOfMonth(mdate));
            }

            return PersianDate;
        }

        /// <summary>
        /// تاریخ هجری به صورت بلند
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string HejriLongDate(DateTime date)
        {
            string result = default;
            string dateString, ss, ms, rs;
            dateString = HejriShortDate(date);
            ss = Convert.ToString(dateString[0]) + dateString[1] + dateString[2] + dateString[3];
            ms = Convert.ToString(dateString[5]) + dateString[6];
            rs = Convert.ToString(dateString[8]) + dateString[9];

            int we;
            var mon = new string[14];
            var w = new string[9];

            w[0] = "يکشنبه";
            w[1] = "دوشنبه";
            w[2] = "سه شنبه";
            w[3] = "چهارشنبه";
            w[4] = "پنجشنبه";
            w[5] = "جمعه";
            w[6] = "شنبه";

            mon[1] = "محرم";
            mon[2] = "صفر";
            mon[3] = "ربیع الاول";
            mon[4] = "ربیع الثانی";
            mon[5] = "جمادی الاول";
            mon[6] = "جمادی الثانی";
            mon[7] = "رجب";
            mon[8] = "شعبان";
            mon[9] = "رمضان";
            mon[10] = "شوال";
            mon[11] = "ذی القعده";
            mon[12] = "ذی الحجه";
            we = (int)DateTime.Now.DayOfWeek;

            result = "  " + rs + "  " + mon[Convert.ToInt32(ms)] + "  " + ss;
            return result;
        }



        /// <summary>
        /// تاریخ میلادی به صورت بلند
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string MiladiLongDate(DateTime date)
        {
            string result = default;
            string dateString, ss, ms, rs;
            dateString = HejriShortDate(date);
            ss = Convert.ToString(dateString[0]) + dateString[1] + dateString[2] + dateString[3];
            ms = Convert.ToString(dateString[5]) + dateString[6];
            rs = Convert.ToString(dateString[8]) + dateString[9];

            int we;
            var mon = new string[14];
            var w = new string[9];

            w[0] = "يکشنبه";
            w[1] = "دوشنبه";
            w[2] = "سه شنبه";
            w[3] = "چهارشنبه";
            w[4] = "پنجشنبه";
            w[5] = "جمعه";
            w[6] = "شنبه";

            mon[1] = "January";
            mon[2] = "Februrary";
            mon[3] = "March";
            mon[4] = "April";
            mon[5] = "May";
            mon[6] = "June";
            mon[7] = "July";
            mon[8] = "August";
            mon[9] = "September";
            mon[10] = "october";
            mon[11] = "November";
            mon[12] = "December";
            we = (int)DateTime.Now.DayOfWeek;

            result = "  " + ss + "  " + mon[Convert.ToInt32(ms)] + "  " + rs;
            return result;
        }




        /*-----------------------------------------------------------------
         * 
         * Server Date
         * 
         -----------------------------------------------------------------*/
        public static bool is_date(string s)
        {
            bool is_dateRet = default;
            is_dateRet = false;
            string m_y;
            int a, k;
            k = 0;
            if (Strings.Len(s) != 10)
            {
                is_dateRet = false;
                return is_dateRet;
            }

            m_y = Convert.ToString(s[0]) + s[1] + s[2] + s[3];
            if (Information.IsNumeric(m_y) == true)
            {
                a = Convert.ToInt32(m_y);
                if (1300d <= Convert.ToDouble(m_y) & Convert.ToDouble(m_y) <= 1500d)
                {
                    k = k + 1;
                }
                else
                {
                    is_dateRet = false;
                    return is_dateRet;
                }
            }
            else
            {
                is_dateRet = false;
                return is_dateRet;
            }

            m_y = Convert.ToString(s[5]) + s[6];
            if (Information.IsNumeric(s[5]) == true & Information.IsNumeric(s[6]) == true)
            {
                a = Convert.ToInt32(m_y);
                if (1d <= Convert.ToDouble(m_y) & Convert.ToDouble(m_y) <= 12d)
                {
                    k = k + 1;
                }
                else
                {
                    is_dateRet = false;
                    return is_dateRet;
                }
            }
            else
            {
                is_dateRet = false;
                return is_dateRet;
            }

            m_y = Convert.ToString(s[8]) + s[9];
            if (Information.IsNumeric(s[8]) == true & Information.IsNumeric(s[9]) == true)
            {
                a = Convert.ToInt32(m_y);
                if (1d <= Convert.ToDouble(m_y) & Convert.ToDouble(m_y) <= 31d)
                {
                    k = k + 1;
                }
                else
                {
                    is_dateRet = false;
                    return is_dateRet;
                }
            }
            else
            {
                is_dateRet = false;
                return is_dateRet;
            }

            if (k == 3)
            {
                is_dateRet = true;
                return is_dateRet;
            }

            return is_dateRet;
        }

        public static int SERVER_MOUNT_NOW()
        {
            int SERVER_MOUNT_NOWRet = default;
            SERVER_MOUNT_NOWRet = 0;
            string S;
            S = server_persin_date_now();
            SERVER_MOUNT_NOWRet = Convert.ToInt32(Convert.ToString(S[5]) + S[6]);
            return SERVER_MOUNT_NOWRet;
        }

        public static string server_persin_date_now()
        {
            string server_persin_date_nowRet = default;
            //server_persin_date_nowRet = "";
            //    string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["PRC_DATABASEConnectionString"].ConnectionString;
            //    var sqlcon = new SqlConnection(strcon);
            //    using (sqlcon)
            //    {
            //        var sqlcom = new SqlCommand();
            //        sqlcom.Connection = sqlcon;
            //        sqlcom.CommandText = "sp_get_server_date";
            //        sqlcom.CommandType = CommandType.StoredProcedure;
            //        sqlcon.Open();
            //        var sqlreader = sqlcom.ExecuteReader();

            //        if (sqlreader.HasRows)
            //        {
            //            sqlreader.Read();
            //            server_persin_date_nowRet = sqlreader.GetString(0).Trim();
            //        }
            //    }

            return server_persin_date_nowRet;


        }

        public static string GET_YEAR_SERVER_DATE()
        {
            string GET_YEAR_SERVER_DATERet = default;
            GET_YEAR_SERVER_DATERet = server_persin_date_now().Substring(0, 4);
            return GET_YEAR_SERVER_DATERet;
        }

        public static string server_time_now()
        {
            string server_time_nowRet = default;
            //server_time_nowRet = "";
            //string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["PRC_DATABASEConnectionString"].ConnectionString;
            //var sqlcon = new SqlConnection(strcon);
            //using (sqlcon)
            //{
            //    var sqlcom = new SqlCommand();
            //    sqlcom.Connection = sqlcon;
            //    sqlcom.CommandText = "SP_GET_SERVER_TIME";
            //    sqlcom.CommandType = CommandType.StoredProcedure;
            //    sqlcon.Open();
            //    var sqlreader = sqlcom.ExecuteReader();

            //    if (sqlreader.HasRows)
            //    {
            //        sqlreader.Read();
            //        server_time_nowRet = sqlreader.GetString(0).Trim();
            //    }
            //}

            return server_time_nowRet;
        }

        public static string server_date_and_time_now()
        {
            string server_date_and_time_nowRet = default;
            server_date_and_time_nowRet = server_persin_date_now() + " " + server_time_now();
            return server_date_and_time_nowRet;
        }

        public static string SERVER_VALID_DATE_TIME_NOW()
        {
            string SERVER_VALID_DATE_TIME_NOWRet = default;
            SERVER_VALID_DATE_TIME_NOWRet = server_persin_date_now().Replace("/", "").Trim() + server_time_now().Replace(":", "").Trim();
            return SERVER_VALID_DATE_TIME_NOWRet;
        }

        //public static DateTime SHAMSI_TO_MILADI(string DATE_SH)
        //{
        //    DateTime SHAMSI_TO_MILADIRet = default;
        //    SHAMSI_TO_MILADIRet = jalali_to_gregorian(Convert.ToLong(Convert.ToString(DATE_SH[0]) + DATE_SH[1] + DATE_SH[2] + DATE_SH[3]), Convert.ToLong(Convert.ToString(DATE_SH[5]) + DATE_SH[6]), Convert.ToLong(Convert.ToString(DATE_SH[8]) + DATE_SH[9]));
        //    return SHAMSI_TO_MILADIRet;
        //}

        public static string GET_DATE_OF_DATE_TIME(string DATE_INPUT)
        {
            string GET_DATE_OF_DATE_TIMERet = default;
            GET_DATE_OF_DATE_TIMERet = DATE_INPUT.Substring(0, 10);
            return GET_DATE_OF_DATE_TIMERet;
        }

        //public static string SHOW_SERVER_DATE_FULL()
        //{
        //    string SHOW_SERVER_DATE_FULLRet = default;
        //    string a, ss, ms, rs;
        //    a = server_persin_date_now();



        //    ss = Convert.ToString(a[0]) + a[1] + a[2] + a[3];
        //    ms = Convert.ToString(a[5]) + a[6];
        //    rs = Convert.ToString(a[8]) + a[9];
        //    // PersianCalenda()
        //    // Dim we As Integer
        //    var mon = new string[14];
        //    var w = new string[9];

        //    w[0] = "يکشنبه";
        //    w[1] = "دوشنبه";
        //    w[2] = "سه شنبه";
        //    w[3] = "چهارشنبه";
        //    w[4] = "پنجشنبه";
        //    w[5] = "جمعه";
        //    w[6] = "شنبه";

        //    mon[1] = "فروردين";
        //    mon[2] = "ارديبهشت";
        //    mon[3] = "خرداد";
        //    mon[4] = "تير";
        //    mon[5] = "مرداد";
        //    mon[6] = "شهريور";
        //    mon[7] = "مهر";
        //    mon[8] = "آبان";
        //    mon[9] = "آذر";
        //    mon[10] = "دی";
        //    mon[11] = "بهمن";
        //    mon[12] = "اسفند";
        //    // we = Now.DayOfWeek



        //    SHOW_SERVER_DATE_FULLRet = w[(int)SHAMSI_TO_MILADI(server_persin_date_now()).DayOfWeek] + " " + rs + "  " + mon[Convert.ToInt32(ms)] + "  " + ss;
        //    return SHOW_SERVER_DATE_FULLRet;

        //}

        //public static string ADD_MINUTE_TO_SERVER_DATETIME(int MINUT)
        //{
        //    string ADD_MINUTE_TO_SERVER_DATETIMERet = default;
        //    ADD_MINUTE_TO_SERVER_DATETIMERet = "";
        //    string S;

        //    S = jalali_to_gregorian2(Convert.ToLong(server_persin_date_now().Substring(0, 4)), Convert.ToLong(server_persin_date_now().Substring(5, 2)), Convert.ToLong(server_persin_date_now().Substring(8, 2)));
        //    DateTime T;
        //    T = Convert.ToDate(S.Substring(0, 4) + "/" + S.Substring(4, 2) + "/" + S.Substring(6, 2) + " " + server_time_now());

        //    T = Convert.ToDate(T.AddMinutes(MINUT).ToString());


        //    ADD_MINUTE_TO_SERVER_DATETIMERet = gregorian_to_jalali2(T.Year, T.Month, T.Day) + REVIEW_DATE(T.Hour) + REVIEW_DATE(T.Minute) + REVIEW_DATE(T.Second);
        //    return ADD_MINUTE_TO_SERVER_DATETIMERet;

        //}
        //public static string ADD_DATE_TO_SERVER_DATETIME(int YEAR, int MOUNT, int DAY)
        //{
        //    string ADD_DATE_TO_SERVER_DATETIMERet = default;
        //    ADD_DATE_TO_SERVER_DATETIMERet = "";
        //    string S;

        //    S = jalali_to_gregorian2(Convert.ToLong(server_persin_date_now().Substring(0, 4)), Convert.ToLong(server_persin_date_now().Substring(5, 2)), Convert.ToLong(server_persin_date_now().Substring(8, 2)));
        //    DateTime T;
        //    T = Convert.ToDate(S.Substring(0, 4) + "/" + S.Substring(4, 2) + "/" + S.Substring(6, 2) + " " + server_time_now());

        //    T = Convert.ToDate(T.AddYears(YEAR).ToString());
        //    T = Convert.ToDate(T.AddMonths(MOUNT).ToString());
        //    T = Convert.ToDate(T.AddDays(DAY).ToString());

        //    // MsgBox(Persian_date.server_persin_date_now)

        //    ADD_DATE_TO_SERVER_DATETIMERet = gregorian_to_jalali2(T.Year, T.Month, T.Day) + REVIEW_DATE(T.Hour) + REVIEW_DATE(T.Minute) + REVIEW_DATE(T.Second);
        //    return ADD_DATE_TO_SERVER_DATETIMERet;

        //}

        public static string REVIEW_DATE(int A)
        {
            string REVIEW_DATERet = default;
            REVIEW_DATERet = A.ToString();
            if (A < 10)
            {
                REVIEW_DATERet = "0" + A;
            }

            return REVIEW_DATERet;
        }

        public static string ADD_SYMBOL_TO_DATE(decimal BEFOR_DATE)
        {
            string ADD_SYMBOL_TO_DATERet = default;
            ADD_SYMBOL_TO_DATERet = "";
            string S;
            S = BEFOR_DATE.ToString();
            ADD_SYMBOL_TO_DATERet = S.Substring(0, 4) + "/" + S.Substring(4, 2) + "/" + S.Substring(6, 2) + " " + S.Substring(8, 2) + ":" + S.Substring(10, 2) + ":" + S.Substring(12, 2);
            return ADD_SYMBOL_TO_DATERet;
        }



        /*-----------------------------------------------------------------
         * 
         * Time
         * 
         -----------------------------------------------------------------*/


        public static DateTime? ToTime(string timeString)
        {
            if (string.IsNullOrEmpty(timeString))
            {
                return null;
            }
            else if (timeString.Count() < 8)
            {
                timeString += ":00";
            }
            DateTime dateTime = DateTime.ParseExact(timeString, "HH:mm:ss",
                                        CultureInfo.InvariantCulture);
            return dateTime;
        }
    }
}