using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Net.NetworkInformation;
using System.IO;
using System.Runtime.InteropServices;
using System.Globalization;

namespace Ticket
{
    public class TicketUtil
    {
        #region path
        public static string base_path = AppDomain.CurrentDomain.BaseDirectory;
        public static string passenger_path = base_path + "Passengers.xml";
        #endregion

        private static long delta = 0x9E3779B8;

        private static string ToHex(string data)
        {
            if (data.Length <= 0)
                return string.Empty;

            StringBuilder sb = new StringBuilder();

            foreach (char c in data)
            {
                sb.Append(((int)c).ToString("x2"));
            }

            return sb.ToString();
        }

        private static string LongArrayToString(long[] data, bool includeLength)
        {
            var length = data.Length;
            long n = (length - 1) << 2;
            if (includeLength)
            {
                var m = data[length - 1];
                if ((m < n - 3) || (m > n))
                    return null;
                n = m;
            }

            StringBuilder sb = new StringBuilder();

            for (var i = 0; i < length; i++)
            {
                sb.Append((char)(data[i] & 0xff));
                sb.Append((char)(data[i] >> 8 & 0xff));
                sb.Append((char)(data[i] >> 16 & 0xff));
                sb.Append((char)(data[i] >> 24 & 0xff));
            }
            if (includeLength)
            {
                return sb.ToString().Substring(0, (int)n);
            }
            else
            {
                return sb.ToString();
            }
        }

        private static long[] StringToLongArray(string data, bool includeLength)
        {
            var length = data.Length;
            var result = new long[2];
            for (var i = 0; i < length; i += 4)
            {
                result[i >> 2] = data[i] | data[i + 1] << 8 | data[i + 2] << 16 | data[i + 3] << 24;
            }
            if (includeLength)
            {
                result[result.Length - 1] = length;
            }
            return result;
        }

        private static string Encode32(string input)
        {
            return Convert.ToBase64String(Encoding.Default.GetBytes(input));
        }

        private static string Encrypt(string key, string data)
        {
            if (data.Length <= 0)
            {
                return "";
            }
            var v = StringToLongArray(data, true);
            var k = StringToLongArray(key, false);
            if (k.Length < 4)
            {
                var temp = new long[4];
                for (var i = 0; i < 4; i++)
                {
                    temp[i] = k.Length - 1 >= i ? k[i] : 0;
                }

                k = temp;
            }

            var n = v.Length - 1;
            long z = v[n], y = v[0];
            int p;
            long mx = 0, e = 0, sum = 0;
            double q = Math.Floor((double)(6 + 52 / (n + 1)));
            while (0 < q--)
            {
                sum = sum + (delta & 0xffffffff);
                e = sum >> 2 & 3;
                for (p = 0; p < n; p++)
                {
                    y = v[p + 1];
                    mx = (z >> 5 ^ y << 2) + (y >> 3 ^ z << 4) ^ (sum ^ y) + (k[p & 3 ^ e] ^ z);
                    z = v[p] = v[p] + mx & 0xffffffff;
                }
                y = v[0];
                mx = (z >> 5 ^ y << 2) + (y >> 3 ^ z << 4) ^ (sum ^ y) + (k[p & 3 ^ e] ^ z);
                z = v[n] = v[n] + mx & 0xffffffff;
            }
            return LongArrayToString(v, false);
        }

        public static string ParamEncrypt(string key, string data)
        {
            return TicketUtil.Encode32(TicketUtil.ToHex(TicketUtil.Encrypt(key, data)));
        }

        static Regex ipRegex = new Regex("[[](?<value>.+?)[]]");
        public static string GetIpAddress()
        {
            var client = new System.Net.WebClient();
            var html = Encoding.Default.GetString(client.DownloadData("http://1111.ip138.com/ic.asp"));
            return ipRegex.Match(html).Groups["value"].Value;
        }

        public static long CheckNetwork()
        {
            Ping ping = new Ping();
            try
            {
                var reply = ping.Send("www.qq.com", 5000);
                return reply.RoundtripTime;
            }
            catch
            {
                return 600;
            }
        }

        public static string GetSex(string no)
        {
            if (no.Length != 15 && no.Length != 18)
            {
                return string.Empty;
            }

            bool IsMale = true;

            switch (no.Length)
            {
                case 15:
                    IsMale = Convert.ToInt32(no[14]) % 2 == 0;
                    break;
                case 18:
                    IsMale = Convert.ToInt32(no[16]) % 2 == 0;
                    break;
            }

            return IsMale ? "M" : "F";
        }

        public static void SaveSelectedPassengers(Passenger[] passengers)
        {
            XmlHelper.SerilizeAnObject(passengers, passenger_path);
        }

        public static Passenger[] ReadSelectedPassengers()
        {
            return XmlHelper.DeserilizeAnObject(typeof(Passenger[]), passenger_path) as Passenger[];
        }

        public static string UrlEncode(string data)
        {
            return System.Web.HttpUtility.UrlEncode(data, Encoding.UTF8);
        }

        private const int INTERNET_COOKIE_HTTPONLY = 0x00002000;

        [DllImport("wininet.dll", SetLastError = true)]
        private static extern bool InternetGetCookieEx(
            string url,
            string cookieName,
            StringBuilder cookieData,
            ref int size,
            int flags,
            IntPtr pReserved);

        /// <summary>
        /// Returns cookie contents as a string
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetCookie(string url)
        {
            int size = 512;
            StringBuilder sb = new StringBuilder(size);
            if (!InternetGetCookieEx(url, null, sb, ref size, INTERNET_COOKIE_HTTPONLY, IntPtr.Zero))
            {
                if (size < 0)
                {
                    return null;
                }
                sb = new StringBuilder(size);
                if (!InternetGetCookieEx(url, null, sb, ref size, INTERNET_COOKIE_HTTPONLY, IntPtr.Zero))
                {
                    return null;
                }
            }
            return sb.ToString();
        }

        public static string ToLongDate(string date)
        {
            if (date.Length != 8)
                return date;

            StringBuilder sb = new StringBuilder();
            sb.Append(date.Substring(0, 4));
            sb.Append("-");
            sb.Append(date.Substring(4, 2));
            sb.Append("-");
            sb.Append(date.Substring(6, 2));

            return sb.ToString();
        }

        static string[] Day = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
        public static string ToCnWeek(DateTime date)
        {
            return Day[Convert.ToInt16(DateTime.Now.DayOfWeek)];
        }

        public static string CardTypeToHtmlString(string id, CardType2[] cardTypes)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("<select id='{0}'>", id));
            if (cardTypes != null && cardTypes.Length > 0)
            {
                foreach (var c in cardTypes)
                {
                    sb.Append(string.Format("<option value='{0}'>{1}</option>", c.id, c.value));
                }
            }

            sb.Append("</select>");

            return sb.ToString();
        }

        public static string DateToString(DateTime date)
        {
            string fmtDate = "ddd MMM dd yyyy HH:mm:ss 'GMT'zz'00' ";
            CultureInfo ciDate = CultureInfo.CreateSpecificCulture("en-US");
            return date.ToString(fmtDate, ciDate) + " (中国标准时间)";
        }

        public static double ToTimestamp(DateTime value)
        {
            TimeSpan span = (value - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());
            return (double)span.TotalSeconds;
        }

        public static DateTime ConvertTimestamp(double timestamp)
        {
            DateTime converted = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            DateTime newDateTime = converted.AddSeconds(timestamp);
            return newDateTime.ToLocalTime();
        }
    }
}
