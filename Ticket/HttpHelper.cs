using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Collections;
using System.Drawing;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Specialized;
using System.IO.Compression;

namespace Ticket
{
    public class HttpHelper
    {
        private CookieContainer cookieContainer = new CookieContainer();
        private string accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
        private string userAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.101 Safari/537.36";
        private string contentType = "application/x-www-form-urlencoded; charset=UTF-8";
        private Encoding Encoding = Encoding.UTF8;

        private int timeout = 2000 * 5;
        private int readTimeOut = 2000 * 5;

        private IWebProxy proxy = null;
        private string cerPath;

        public HttpHelper()
        {
        }

        public HttpHelper(Encoding encoding)
        {
            this.Encoding = encoding;
        }

        public HttpHelper(Encoding encoding, string cerPath)
            : this(encoding)
        {
            this.cerPath = cerPath;
        }

        /// <summary>
        /// 设置证书
        /// </summary>
        /// <param name="objhttpItem"></param>
        private void SetCer(HttpWebRequest request, string cerPath)
        {
            if (string.IsNullOrEmpty(cerPath))
            {
                return;
            }

            if (!File.Exists(cerPath))
            {
                return;
            }

            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(CheckValidationResult);

            X509Certificate objx509 = new X509Certificate(cerPath);
            request.ClientCertificates.Add(objx509);
        }

        public bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }

        public void ClearCookies()
        {
            cookieContainer = new CookieContainer();
        }

        public void SetProxy(IWebProxy proxy)
        {
            this.proxy = proxy;
        }

        public void ClearProxy()
        {
            this.proxy = null;
        }

        public void SetEncoding(Encoding encoding)
        {
            this.Encoding = encoding;
        }

        public void SetTimeout(int sec)
        {
            this.timeout = sec;
            this.readTimeOut = sec;
        }

        public Cookie GetCookie(string url, string cookieName)
        {
            if (this.cookieContainer == null)
            {
                return null;
            }

            try
            {
                return this.cookieContainer.GetCookies(new Uri(url))[cookieName];
            }
            catch
            {
                return null;
            }
        }

        public CookieCollection GetCookies(string url)
        {
            if (this.cookieContainer == null)
            {
                return null;
            }

            try
            {
                return this.cookieContainer.GetCookies(new Uri(url));
            }
            catch
            {
                return null;
            }
        }

        public string GetCookiesString(string url)
        {
            var cookies = GetCookies(url);
            if (cookies == null || cookies.Count <= 0)
                return string.Empty;

            StringBuilder sb = new StringBuilder();

            foreach (Cookie cookie in cookies)
            {
                sb.Append(cookie.Name);
                sb.Append("=");
                sb.Append(cookie.Value);
                sb.Append(";");
            }

            return sb.ToString().TrimEnd(';');
        }

        public void SetCookies(string url, string cookies)
        {
            if (this.cookieContainer == null)
            {
                this.cookieContainer = new CookieContainer();
            }

            this.cookieContainer.SetCookies(new Uri(url), cookies);
        }

        /// <summary>
        /// 得到网页信息
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="isPost"></param>
        /// <param name="referer"></param>
        /// <param name="cType"></param>
        /// <returns></returns>
        public byte[] GetHtml(string url, byte[] data, bool isPost, bool isKeepAlive = false, string referer = "", string cType = "")
        {
            HttpWebRequest httpWebRequest = null;
            HttpWebResponse httpWebResponse = null;
            try
            {
                httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                httpWebRequest.Accept = accept;
                httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
                httpWebRequest.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8");
                httpWebRequest.KeepAlive = isKeepAlive;
                httpWebRequest.Method = isPost ? "POST" : "GET";

                httpWebRequest.CookieContainer = this.cookieContainer;

                httpWebRequest.Referer = string.IsNullOrEmpty(referer) ? System.Web.HttpUtility.UrlEncode(url) : referer;
                httpWebRequest.UserAgent = userAgent;

                httpWebRequest.Timeout = this.timeout;
                httpWebRequest.ReadWriteTimeout = this.readTimeOut;

                httpWebRequest.ServicePoint.Expect100Continue = false;

                SetCer(httpWebRequest, cerPath);

                httpWebRequest.Proxy = proxy;

                if (isPost)
                {
                    httpWebRequest.ContentType = string.IsNullOrEmpty(cType) ? contentType : cType;

                    if (data != null)
                    {
                        httpWebRequest.ContentLength = data.Length;
                        using (Stream stream = httpWebRequest.GetRequestStream())
                        {
                            stream.Write(data, 0, data.Length);
                        }
                    }
                }

                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if (httpWebResponse.Headers["Set-Cookie"] != null)
                {
                    this.cookieContainer.SetCookies(httpWebRequest.RequestUri, httpWebResponse.Headers["Set-Cookie"]);
                }

                var responseStream = httpWebResponse.GetResponseStream();
                if (httpWebResponse.ContentEncoding.ToLower().Contains("gzip"))
                {
                    responseStream = new GZipStream(responseStream, CompressionMode.Decompress);
                }

                //设置COOKIES信息
                //CookieDomain(this.cookieContainer);
                return StreamToBytes(responseStream);
            }
            catch
            {
                return null;
            }
            finally
            {
                if (httpWebRequest != null)
                {
                    httpWebRequest.Abort();
                }

                if (httpWebResponse != null)
                {
                    httpWebResponse.Close();
                }
            }
        }

        public byte[] GetHtml2(string url, Dictionary<string, string> headers, bool isPost, byte[] data)
        {
            if (headers == null || headers.Count <= 0)
            {
                return null;
            }

            HttpWebRequest httpWebRequest = null;
            HttpWebResponse httpWebResponse = null;

            try
            {
                httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);

                foreach (var header in headers)
                {
                    SetHeaderValue(httpWebRequest.Headers, header.Key, header.Value);
                }

                SetCer(httpWebRequest, cerPath);

                httpWebRequest.Proxy = proxy;
                httpWebRequest.Method = isPost ? "POST" : "GET";
                if (isPost)
                {
                    if (data != null)
                    {
                        using (Stream stream = httpWebRequest.GetRequestStream())
                        {
                            stream.Write(data, 0, data.Length);
                        }
                    }
                }

                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                if (httpWebResponse.Headers["Set-Cookie"] != null)
                {
                    this.cookieContainer.SetCookies(httpWebRequest.RequestUri, httpWebResponse.Headers["Set-Cookie"]);
                }

                var responseStream = httpWebResponse.GetResponseStream();
                if (httpWebResponse.ContentEncoding.ToLower().Contains("gzip"))
                {
                    responseStream = new GZipStream(responseStream, CompressionMode.Decompress);
                }

                //设置COOKIES信息
                //CookieDomain(this.cookieContainer);
                return StreamToBytes(responseStream);
            }
            catch
            {
                return null;
            }
            finally
            {
                if (httpWebRequest != null)
                {
                    httpWebRequest.Abort();
                }

                if (httpWebResponse != null)
                {
                    httpWebResponse.Close();
                }
            }
        }

        public static void SetHeaderValue(WebHeaderCollection header, string name, string value)
        {
            var property = typeof(WebHeaderCollection).GetProperty("InnerCollection",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            if (property != null)
            {
                var collection = property.GetValue(header, null) as NameValueCollection;
                collection[name] = value;
            }
        }
        /// <summary>
        /// 获取网页信息
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="isPost"></param>
        /// <param name="referer"></param>
        /// <param name="cType"></param>
        /// <returns></returns>
        public byte[] GetHtml(string url, string data, bool isPost, string referer = "", string cType = "")
        {
            byte[] dataBytes = null;

            if (!string.IsNullOrEmpty(data))
            {
                dataBytes = Encoding.Default.GetBytes(data);
            }

            return GetHtml(url, dataBytes, isPost, false, referer, cType);
        }

        public byte[] GetHtml(string url, string data, bool isPost, bool isKeepAlive, string referer = "", string cType = "")
        {
            byte[] dataBytes = null;

            if (!string.IsNullOrEmpty(data))
            {
                dataBytes = Encoding.Default.GetBytes(data);
            }

            return GetHtml(url, dataBytes, isPost, isKeepAlive, referer, cType);
        }

        private byte[] StreamToBytes(Stream stream)
        {
            if (stream == null)
            {
                return null;
            }

            List<byte> list = new List<byte>();
            try
            {
                int i = 0;
                while ((i = stream.ReadByte()) != -1)
                {
                    list.Add((byte)i);
                }

                return list.ToArray();
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
        }

        private void CookieDomain(CookieContainer cookieContainer)
        {
            System.Type _ContainerType = typeof(CookieContainer);
            Hashtable table = (Hashtable)_ContainerType.InvokeMember("m_domainTable",
                                       System.Reflection.BindingFlags.NonPublic |
                                       System.Reflection.BindingFlags.GetField |
                                       System.Reflection.BindingFlags.Instance,
                                       null,
                                       cookieContainer,
                                       new object[] { });
            ArrayList keys = new ArrayList(table.Keys);
            foreach (string keyObj in keys)
            {
                string key = (keyObj as string);
                if (key[0] == '.')
                {
                    string newKey = key.Remove(0, 1);
                    table[newKey] = table[keyObj];
                }
            }
        }

        public string GetHtml(string url)
        {
            byte[] htmlBytes = GetHtml(url, string.Empty, false, string.Empty, string.Empty);
            if (htmlBytes == null || htmlBytes.Length <= 0)
            {
                return string.Empty;
            }
            else
            {
                return Encoding.GetString(htmlBytes);
            }
        }

        public string GetHtml(string url, Dictionary<string, string> headers)
        {
            var htmlBytes = GetHtml2(url, headers, false, null);
            if (htmlBytes == null || htmlBytes.Length <= 0)
            {
                return string.Empty;
            }
            else
            {
                return Encoding.GetString(htmlBytes);
            }
        }

        public string GetHtml(string url, string referer)
        {
            byte[] htmlBytes = GetHtml(url, string.Empty, false, referer, string.Empty);
            if (htmlBytes == null || htmlBytes.Length <= 0)
            {
                return string.Empty;
            }
            else
            {
                return Encoding.GetString(htmlBytes);
            }
        }

        public Image GetImage(string url)
        {
            byte[] bytes = GetHtml(url, string.Empty, false, string.Empty, string.Empty);
            if (bytes == null || bytes.Length <= 0)
            {
                return null;
            }
            else
            {
                return Image.FromStream(new MemoryStream(bytes));
            }
        }

        public Image GetImage(string url, string referer)
        {
            byte[] bytes = GetHtml(url, string.Empty, false, referer, string.Empty);
            if (bytes == null || bytes.Length <= 0)
            {
                return null;
            }
            else
            {
                return Image.FromStream(new MemoryStream(bytes));
            }
        }

        public Image GetImage(string url, Dictionary<string, string> headers)
        {
            byte[] bytes = GetHtml2(url, headers, false, null);
            if (bytes == null || bytes.Length <= 0)
            {
                return null;
            }
            else
            {
                return Image.FromStream(new MemoryStream(bytes));
            }
        }

        public string GetHtml(string url, string referer, string contentType)
        {
            byte[] htmlBytes = GetHtml(url, string.Empty, false, referer, contentType);

            if (htmlBytes == null || htmlBytes.Length <= 0)
            {
                return string.Empty;
            }
            else
            {
                return Encoding.GetString(htmlBytes);
            }
        }

        public string PostHtml(string url, string data)
        {
            byte[] htmlBytes = GetHtml(url, data, true, string.Empty, string.Empty);
            if (htmlBytes == null || htmlBytes.Length <= 0)
            {
                return string.Empty;
            }
            else
            {
                return Encoding.GetString(htmlBytes);
            }
        }

        public string PostHtml(string url, string data, bool isKeepAlive)
        {
            byte[] htmlBytes = GetHtml(url, data, true, isKeepAlive, string.Empty, string.Empty);
            if (htmlBytes == null || htmlBytes.Length <= 0)
            {
                return string.Empty;
            }
            else
            {
                return Encoding.GetString(htmlBytes);
            }
        }

        public string PostHtml(string url, string data, bool isKeepAlive, string referer)
        {
            byte[] htmlBytes = GetHtml(url, data, true, isKeepAlive, referer, string.Empty);
            if (htmlBytes == null || htmlBytes.Length <= 0)
            {
                return string.Empty;
            }
            else
            {
                return Encoding.GetString(htmlBytes);
            }
        }

        public string PostHtml(string url, byte[] data)
        {
            byte[] htmlBytes = GetHtml(url, data, true, false, string.Empty, string.Empty);
            if (htmlBytes == null || htmlBytes.Length <= 0)
            {
                return string.Empty;
            }
            else
            {
                return Encoding.GetString(htmlBytes);
            }
        }

        public string PostHtml(string url, Dictionary<string, string> headers, byte[] data)
        {
            byte[] htmlBytes = GetHtml2(url, headers, true, data);
            if (htmlBytes == null || htmlBytes.Length <= 0)
            {
                return string.Empty;
            }
            else
            {
                return Encoding.GetString(htmlBytes);
            }
        }

        public string PostHtml(string url, byte[] data, bool isKeepAlive)
        {
            byte[] htmlBytes = GetHtml(url, data, true, isKeepAlive, string.Empty, string.Empty);
            if (htmlBytes == null || htmlBytes.Length <= 0)
            {
                return string.Empty;
            }
            else
            {
                return Encoding.GetString(htmlBytes);
            }
        }

        public string PostHtml(string url, string data, string referer)
        {
            byte[] htmlBytes = GetHtml(url, data, true, referer, string.Empty);
            if (htmlBytes == null || htmlBytes.Length <= 0)
            {
                return string.Empty;
            }
            else
            {
                return Encoding.GetString(htmlBytes);
            }
        }

        public string PostHtml(string url, byte[] data, string referer)
        {
            byte[] htmlBytes = GetHtml(url, data, true, false, referer, string.Empty);
            if (htmlBytes == null || htmlBytes.Length <= 0)
            {
                return string.Empty;
            }
            else
            {
                return Encoding.GetString(htmlBytes);
            }
        }

        public string PostHtml(string url, string data, string referer, string ctype)
        {
            byte[] htmlBytes = GetHtml(url, data, true, referer, ctype);
            if (htmlBytes == null || htmlBytes.Length <= 0)
            {
                return string.Empty;
            }
            else
            {
                return Encoding.GetString(htmlBytes);
            }
        }

        public string PostHtml(string url, byte[] data, string referer, string ctype)
        {
            byte[] htmlBytes = GetHtml(url, data, true, false, referer, ctype);
            if (htmlBytes == null || htmlBytes.Length <= 0)
            {
                return string.Empty;
            }
            else
            {
                return Encoding.GetString(htmlBytes);
            }
        }
    }
}
